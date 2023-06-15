;#DropDB TestTicketingSystemEasyTest

#Application TestTicketingSystemWin
;#Application TestTicketingSystemWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef TestTicketingSystemWin

*Action About...
 
*Action OK

#EndIf

#IfDef TestTicketingSystemWeb
*Action Navigation(My Details)
#EndIf
