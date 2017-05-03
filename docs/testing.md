# Testkonzept

Abschnitt            | Inhalt
---------------------|--------
ID                   | T-1
Getestete User Story | [#1](https://github.com/ICT-BBC/mod-pr-scrum/issues/1)
Vorbedingungen       | Das Programm kann gestartet werden
Ablauf               | 1. Der Benutzer klickt auf No Account. 2. Der Benutzer Registriert sich.
Erwartetes Resultat  | Die Registrierung ist erfolgreich (Das Programm gibt keine Fehlermeldung aus und der User wird in der Datenbank erfasst).

Abschnitt            | Inhalt
---------------------|--------
ID                   | NT-1
Getestete User Story | [#1](https://github.com/ICT-BBC/mod-pr-scrum/issues/1)
Vorbedingungen       | Der Benutzer hat das Programm offen und hat auf den Button "Sign in now" gedrückt 
Ablauf               | 1. Der Benutzer versucht sich ein 2. mal mit der selben Email zu registrieren 
Erwartetes Resultat  | Es wird eine Fehlermeldung kommen die sagt, dass diese Email schon existiert.

Abschnitt            | Inhalt
---------------------|--------
ID                   | NT-2
Getestete User Story | [#2](https://github.com/ICT-BBC/mod-pr-scrum/issues/2)
Vorbedingungen       | Der Benutzer hat das Programm offen und hat auf den Button "Sign in now" gedrückt 
Ablauf               | 1. Der Benutzer gibt bei "Password repeat" nicht das selbe ein wie bei "Password"
Erwartetes Resultat  | Es wird eine Fehlermeldung ausgegeben, welche aussagt dass die beiden Passwort boxen identisch sein müssen. 

Abschnitt            | Inhalt
---------------------|--------
ID                   | T-2
Getestete User Story | [#2](https://github.com/ICT-BBC/mod-pr-scrum/issues/2)
Vorbedingungen       | Der Benutzer ist registriert
Ablauf               | 1. Der Benutzer Meldet sich mit den zuvor registrierten Accountdaten an.
Erwartetes Resultat  | Die Anmeldung ist erfolgreich, weil ihm keine Fehlermeldung angezeigt wird.

Abschnitt            | Inhalt
---------------------|--------
ID                   | NT-3
Getestete User Story | [#2](https://github.com/ICT-BBC/mod-pr-scrum/issues/2)
Vorbedingungen       | Der Benutzer hat das Programm offen.
Ablauf               | 1. Der Benutzer versucht sich anzumelden ohne sich vorher angemeldet zu haben.
Erwartetes Resultat  | Es wird eine Fehlermeldung ausgegeben, welche aussagt dass entweder das Passwort oder die Email falsch ist. 

Abschnitt            | Inhalt
---------------------|--------
ID                   | T-3
Getestete User Story | [#26](https://github.com/ICT-BBC/mod-pr-scrum/issues/26)
Vorbedingungen       | Der Benutzer hat das Programm offen, hat sich registriert und ist angemeldet.
Ablauf               | 1. Der Benutzer geht im Hauptmenu auf My Profile und drückt dort auf den editier button, gibt seine neuen Daten ein und drückt dann auf den Speichern button.
Erwartetes Resultat  | Die neu eingegebenen Daten werden in der Datebank aktualisiert. 

  #### [Zuück](../README.md)
