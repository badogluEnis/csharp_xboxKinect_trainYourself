# Technische Dokumentation
  
  ## Entwicklungumgebung
  
  
  ### Setup
  Dieses Projekt wurde auf Windows 7 Enterprise Service Pack 1 mit Visual Studio 2015 Professional (Verison 14.0.25431.01 Update 3) programmiert. 
  
  Folgende Gadgets werden verwendet:
  Kinect v1
  
  
  ### Code Style
  ...
  
  
  
  ## Architektur
    
  ### Genereller Aufbau der Applikation
  ...
  
  ### Klassendiagramm
  ...
  
  
  ## Design
    
  ### Mockups
  Wir haben für unser Projekt folgendes GUI Layout vorgesehen:
  * [Startscreen und Anmelden](img/start.png)
  * [Registrierungsscreen 1](img/register.png)
  * [Registrierungsscreen 2](img/register2.png)
  * [Hauptmenu](img/mainmenu.png)
  * [Liveview Push-Ups](img/liveview.png)
  * [Liveview Sit-Ups](img/liveview2.png)
  * [Profil](img/profile.png)
  
  
  ### Sequenzdiagramm
  Unser aktuelles Sequenzdiagramm finden sie [hier](img/sd_tys.PNG).
  
  ## Datenbank und Entity Framework
  In unserem Projekt haben wir auch eine Datenbank integriert. Um Userdaten sowie auch Trainingsfortschritte zu speichern.
  Wir brauchen in unserem Projekt Entity Framework (Verison: 6.1.3) mit Code first.
  
  In unserem Projekt haben wir folgende zwei Tabellen: User und Score. 
  In der User Tabelle werden Daten gespeichert welche jeder User nur ein Mal hat, zum Bespiel: Highscore, Name, Email usw... 
  Hingegen bei der Score Tabelle werden alle Scores vom User gespeichert, dass heisst, jeder User hat mehrere Scores.
  
  Das aktuelle ERM von unserer Datenbank sehen sie [hier](img/erm_tys.PNG).
  
  
  ## Handling der Kinect
  Wie vorher in der Dokumentation erwähnt, haben wir in unserem Projekt eine Kinect eingebaut. In diesem Teil der Doku werden wir alles   was in unserem Projekt mit der Kinect zu tun hat, dokumentieren und festhalten.
  
  ### Die Kamera in der Liveview
  In der Live View sieht man einen Livestrem von sich selber beim Übungen machen.
  
 ##### Wie haben wir es gemacht?
  Wir haben im Designer ein Image Paltziert welches wir im Code behind per Namen ansprechen. Wir bekommen von der Kineckt ein Bild in    Binär, dieser Binärcode wird in einem Array abgespeichert. Danach wird eine Writable Bitmap hergestellt und in diese der verher   gefüllte Array übertragen. Vorher wird noch der "Zeilenumbruch" festegelegt, damit das Programm weiss wo es den Binär Code trennen muss. Es wird immer wieder diese Writable Bitmap in unser Image geladen. 
  
  
  
  
  #### [Zurück](../README.md)
