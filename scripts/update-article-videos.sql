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
SET MainVideoUrl = videos.VideoUrl
FROM Articles AS a
INNER JOIN (VALUES
    (N'Yapay Zekâ ile Çalışırken Daha İyi Sorular Sormak', N'https://www.youtube.com/watch?v=hGl7124T87A'),
    (N'Bir Web Projesinde API ve Veritabanı Nasıl Birlikte Çalışır?', N'https://www.youtube.com/watch?v=tdUAJTOLkIU'),
    (N'Bir Spor Günlüğünde Hangi Bilgiler Tutulabilir?', N'https://www.youtube.com/watch?v=AgCnpt0GdxA'),
    (N'Takım Sporlarında İletişimin Rolü', N'https://www.youtube.com/watch?v=BifNDGCjCfc'),
    (N'Mevsim Sebzeleriyle Fırın Tepsisi Hazırlamak', N'https://www.youtube.com/watch?v=HTyBDUFebyo'),
    (N'Haftalık Yemek Planını Kolaylaştıran Bir Alışveriş Listesi', N'https://www.youtube.com/watch?v=8nS2g3u4jA4'),
    (N'Şehir Gezisi İçin Esnek Bir Rota Hazırlamak', N'https://www.youtube.com/watch?v=8rdrQQywgUo'),
    (N'Seyahat Fotoğraflarında Bir Hikâye Kurmak', N'https://www.youtube.com/watch?v=7ZVyNjKSr0M'),
    (N'Bir Sergiyi Gezerken Kendi Notlarınızı Oluşturmak', N'https://www.youtube.com/watch?v=0OloYD_kSbU'),
    (N'Okuma Günlüğüyle Kitapları Hatırlamak', N'https://www.youtube.com/watch?v=VUgBhyShx3w')
) AS videos(Title, VideoUrl) ON a.Title = videos.Title
WHERE NULLIF(LTRIM(RTRIM(a.MainVideoUrl)), N'') IS NULL;
SELECT @@ROWCOUNT AS UpdatedArticles;
-- Magnific Popup, YouTube video kimliğini v= parametresinden okur.
UPDATE Articles
SET MainVideoUrl = N'https://www.youtube.com/watch?v=' + RIGHT(MainVideoUrl, 11)
WHERE MainVideoUrl LIKE N'https://www.youtube.com/embed/%'
  AND LEN(MainVideoUrl) = LEN(N'https://www.youtube.com/embed/') + 11;
SELECT @@ROWCOUNT AS ConvertedVideoUrls;
COMMIT TRANSACTION;
SELECT ArticleId, Title, MainVideoUrl FROM Articles ORDER BY ArticleId;
