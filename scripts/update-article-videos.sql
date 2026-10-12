-- Mevcut Articles kayıtlarındaki boş MainVideoUrl alanlarını doldurur.
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
BEGIN TRANSACTION;
-- Konuya uygun kısa videolar. Mevcut video eşleştirmeleri korunur.
UPDATE a
SET MainVideoUrl = videos.EmbedUrl
FROM Articles AS a
INNER JOIN (VALUES
    (N'Yapay Zekâ ile Çalışırken Daha İyi Sorular Sormak', N'https://www.youtube.com/embed/hGl7124T87A'),
    (N'Bir Web Projesinde API ve Veritabanı Nasıl Birlikte Çalışır?', N'https://www.youtube.com/embed/tdUAJTOLkIU'),
    (N'Bir Spor Günlüğünde Hangi Bilgiler Tutulabilir?', N'https://www.youtube.com/embed/AgCnpt0GdxA'),
    (N'Takım Sporlarında İletişimin Rolü', N'https://www.youtube.com/embed/BifNDGCjCfc'),
    (N'Mevsim Sebzeleriyle Fırın Tepsisi Hazırlamak', N'https://www.youtube.com/embed/HTyBDUFebyo'),
    (N'Haftalık Yemek Planını Kolaylaştıran Bir Alışveriş Listesi', N'https://www.youtube.com/embed/8nS2g3u4jA4'),
    (N'Şehir Gezisi İçin Esnek Bir Rota Hazırlamak', N'https://www.youtube.com/embed/8rdrQQywgUo'),
    (N'Seyahat Fotoğraflarında Bir Hikâye Kurmak', N'https://www.youtube.com/embed/7ZVyNjKSr0M'),
    (N'Bir Sergiyi Gezerken Kendi Notlarınızı Oluşturmak', N'https://www.youtube.com/embed/0OloYD_kSbU'),
    (N'Okuma Günlüğüyle Kitapları Hatırlamak', N'https://www.youtube.com/embed/VUgBhyShx3w')
) AS videos(Title, EmbedUrl) ON a.Title = videos.Title
WHERE NULLIF(LTRIM(RTRIM(a.MainVideoUrl)), N'') IS NULL;
SELECT @@ROWCOUNT AS UpdatedArticles;
COMMIT TRANSACTION;
SELECT ArticleId, Title, MainVideoUrl FROM Articles ORDER BY ArticleId;
