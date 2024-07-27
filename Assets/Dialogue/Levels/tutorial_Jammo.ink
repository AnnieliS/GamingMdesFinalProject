INCLUDE ../globals.ink


{ JAMMO_CONNECTED == false : -> main | -> connected }

=== main ===
inTeRnet dOwn. please recoNnect #speaker:Roto #portrait:dia_avatar_roto_dead
->questions
===questions===
+[Bulb?]
    ->no
+[Dad?]
->no
+[reconnect]
 ->reconnect

===no===
inTeRnet dOwn. please recoNnect #speaker:Roto #portrait:dia_avatar_roto_dead
->questions

===reconnect===
starting reconnection process... #speaker:Roto #portrait:dia_avatar_roto_dead
~ JAMMO_CONNECTED = true
~enterPuzzle("wifiConnected")
->END

===connected===
Connection successful. #speaker:Roto #portrait:dia_avatar_roto
... #speaker:Roto #portrait:dia_avatar_roto_sideeye
(Please press ESC and QUIT back to the room) #speaker:Roto #portrait:dia_avatar_roto

->END