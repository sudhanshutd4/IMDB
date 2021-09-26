IF OBJECT_ID ('dbo.actors') IS NOT NULL
	DROP TABLE dbo.actors
GO

CREATE TABLE dbo.actors
	(
	ActorID     INT IDENTITY NOT NULL,
	Name        NVARCHAR (max),
	Description NVARCHAR (max),
	DateOfBirth DATETIME2 NOT NULL,
	Gender      NVARCHAR (max),
	CONSTRAINT PK_actors PRIMARY KEY (ActorID)
	)
GO

IF OBJECT_ID ('dbo.producers') IS NOT NULL
	DROP TABLE dbo.producers
GO

CREATE TABLE dbo.producers
	(
	ProducerID  INT IDENTITY NOT NULL,
	Name        NVARCHAR (max),
	Description NVARCHAR (max),
	DateOfBirth DATETIME2 NOT NULL,
	Company     NVARCHAR (max),
	Gender      NVARCHAR (max),
	CONSTRAINT PK_producers PRIMARY KEY (ProducerID)
	)
GO

IF OBJECT_ID ('dbo.movies') IS NOT NULL
	DROP TABLE dbo.movies
GO

CREATE TABLE dbo.movies
	(
	MovieID       INT IDENTITY NOT NULL,
	Name          NVARCHAR (max),
	DateOfRelease DATETIME2 NOT NULL,
	ProducerID    INT,
	Description   NVARCHAR (max),
	CONSTRAINT PK_movies PRIMARY KEY (MovieID),
	CONSTRAINT FK_movies_producers_ProducerID FOREIGN KEY (ProducerID) REFERENCES dbo.producers (ProducerID)
	)
GO

CREATE INDEX IX_movies_ProducerID
	ON dbo.movies (ProducerID)
GO

IF OBJECT_ID ('dbo.movieactorMapping') IS NOT NULL
	DROP TABLE dbo.movieactorMapping
GO

CREATE TABLE dbo.movieactorMapping
	(
	MoviesMovieID INT,
	ActorsActorID INT,
	MappingId     INT IDENTITY NOT NULL,
	CONSTRAINT PK_movieactorMapping PRIMARY KEY (MappingId),
	CONSTRAINT FK_movieactorMapping_actors_ActorsActorID FOREIGN KEY (ActorsActorID) REFERENCES dbo.actors (ActorID),
	CONSTRAINT FK_movieactorMapping_movies_MoviesMovieID FOREIGN KEY (MoviesMovieID) REFERENCES dbo.movies (MovieID)
	)
GO

CREATE INDEX IX_movieactorMapping_ActorsActorID
	ON dbo.movieactorMapping (ActorsActorID)
GO

CREATE INDEX IX_movieactorMapping_MoviesMovieID
	ON dbo.movieactorMapping (MoviesMovieID)
GO








