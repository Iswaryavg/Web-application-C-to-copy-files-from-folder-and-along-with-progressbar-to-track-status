# Web-application-C-to-copy-files-from-folder-and-along-with-progressbar-to-track-status
Title-Web application showing the progress of copying/moving using HTML5,CSS3,Bootstrap,C# and SIGNALR
**************************************************************************************************************************************
IDE: Visual Studio 2019 
OS: Windows

Functional Requirements:

Developed a web application on C#, using standard .net components as well as other open source libraries (e.g. jquery)

The application is used to copy (or move) files from one folder to another, using a text configuration file with the list of files to transfer.

****************************************************************************************************************************************
The application copies or move with the help of
 System.IO.File.Copy(sourcepath + "\\" + fc, destinationpath + "\\" + fc);
 System.IO.File.Move(sourcepath + "\\" + fm, destinationpath + "\\" + fm);

Source and target folders are defined in the application configuration file. To move or to copy files is defined by a user in UI (checkbox).
Approach:

Created three folders in the path below
  <add key="filepath" value="D:\filepath\path.txt"/>
    <add key="source" value="D:\source"/>
    <add key="destination" value="D:\destination"/>
****************************************************************************************************************************************

