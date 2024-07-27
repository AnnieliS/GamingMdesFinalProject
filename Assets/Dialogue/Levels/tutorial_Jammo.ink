INCLUDE ../globals.ink


{ JAMMO_CONNECTED == false : -> main | -> connected }

=== main ===
inTeRnet dOwn. please recoNnect #speaker:Roto #portrait:dia_avatar_tutorial
->questions
===questions===
+[Bulb?]
    ->no
+[Dad?]
->no
+[reconnect]
 ->reconnect

===no===
inTeRnet dOwn. please recoNnect #speaker:Roto #portrait:dia_avatar_tutorial
->questions

===reconnect===
starting reconnection process... #speaker:Roto #portrait:dia_avatar_tutorial
~ JAMMO_CONNECTED = true
~enterPuzzle("wifiConnected")
->END

===connected===
Connection successful. #speaker:Roto #portrait:dia_avatar_tutorial
... #speaker:Roto #portrait:dia_avatar_tutorial
(Please press ESC and QUIT back to the room) #speaker:Roto #portrait:dia_avatar_tutorial

->END