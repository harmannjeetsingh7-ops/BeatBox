
# BeatBox - Music Playlist Curator

## Project Description
BeatBox is an ASP.NET Core MVC web application that allows
users to create and manage music playlists and songs.

This project was developed for COMP 2084 Assignment 2
at Georgian College.

## Features
- Create, view, edit, and delete playlists
- Create, view, edit, and delete songs
- Assign songs to playlists using a dropdown
- Store information in a SQL Server database
- One-to-many relationship between playlists and songs
- ASP.NET Core MVC with Razor Views

## Technologies Used
- C#
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- HTML
- Bootstrap
- GitHub

## Database
The application uses a SQL Server database named beatBox.

Tables:
- Playlists
- Songs

One playlist can contain multiple songs.

## How to Run
1. Open the project in Visual Studio.
2. Configure DefaultConnection in appsettings.json.
3. Make sure SQL Server is running.
4. Run Update-Database if the database has not been created.
5. Run the application using HTTPS.

## Author
Harmanjeet Singh
COMP 2084 - Georgian College
