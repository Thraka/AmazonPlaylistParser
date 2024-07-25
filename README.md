This converts an Amazon Playlist to a CSV file. The playlist content is copied by selecting text in the web browser version of the Amazon Music player, and pasting it to a file. Run the program and pass the name path of the file as the first argument. A `songs.csv` file is created in the current directory.

To create the playlist file:

1. Open the Amazon Music player and browser to your playlist.
1. If your playlist is large, zoom out as much as possible in the web browser.
1. Select above the first item, but below the header information of the playlist.
1. Drag down to the bottom of the playlist.
1. Press CTRL+C to copy the text.
1. Open a text editor and paste the content.


The content of the text file shoud look like this, if the playlist had two songs:

```
Tribe
Tribe
Gruntruck
Push
04:21
Crazy Love
Crazy Love
Gruntruck
Push
04:54
```

or this, if the track number was copied also (sometimes it is, sometimes it isn't):

```
1
Tribe
Tribe
Gruntruck
Push
04:21
2
Crazy Love
Crazy Love
Gruntruck
Push
04:54

```

