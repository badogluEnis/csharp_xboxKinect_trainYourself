# Technische Dokumentation

Folgende Inhalte sind Zwingend

* Entwicklungsumgebung
  * Setup
  * Code Style
* Architektur
  * Genereller Aufbau der APplikation
  * Klassendiagramm
* Design
  * Sequenzdiagramme
  ## Setup
  Dieses Projekt wurde auf Windows 7 Enterprise Service Pack 1 mit Visual Studio 2015 Professional (Verison 14.0.25431.01 Update 3) programmiert. 
  
  Wir haben für unser Projekt folgendes GUI Layout vorgesehen:
  [Startscreen](img/start.PNG)
  [Anmeldescreen](img/login.PNG)
  [Registrierungsscreen](img/register.PNG)
  [Hauptmenu](img/mainmenu.PNG)
  [Liveview](img/liveview.PNG)
  [Profil](img/profile.PNG)
  

  In unserem Projekt haben wir auch eine Datenbank integriert. Um Userdaten sowie auch Trainingsfortschritte zu speichern.
  Wir brauchen in unserem Projekt Entity Framework (Verison: 6.1.3) mit Code first.
  
  Das aktuelle ERM von unserer Datenbank sehen sie [hier](img/erm_tys.PNG).
  
Folgende optional (je nach Projekt)
* Weitere technisch relevante Aspekte