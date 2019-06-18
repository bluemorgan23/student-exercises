SELECT * FROM Artist
WHERE YearEstablished = 2006
OR YearEstablished < 1990;

SELECT * FROM Artist
ORDER BY YearEstablished DESC;

SELECT
    s.Title AS 'Song Title',
    s.SongLength,
    a.Title AS 'Album Title',
    ar.ArtistName
    FROM Song s
    JOIN Album a ON a.Id = s.AlbumId
    JOIN Artist ar ON ar.Id = s.ArtistId
    ORDER BY SongLength DESC;

SELECT
    COUNT(s.Title) AS 'Number of Songs on the album',
    a.Title AS 'Album Title'
    FROM Song s
    JOIN Album a ON s.AlbumId = a.Id
    GROUP BY a.Title;

SELECT
    COUNT(a.Id) AS 'Number of Albums by artist',
    ar.ArtistName
    FROM Artist ar
    JOIN Album a ON a.ArtistId = ar.Id
    GROUP BY ArtistName;

SELECT
    COUNT(a.Id) AS 'Albums',
    ar.ArtistName
    FROM Album a
    JOIN Artist ar ON ar.Id = a.ArtistId
    GROUP BY ar.ArtistName;

