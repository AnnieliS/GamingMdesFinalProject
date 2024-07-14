INCLUDE ../globals.ink

-> main

=== main ===
~ playEmote("talk")
ugh #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
UGH #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
... #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("talk")
UGHHHH!!!! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
... #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
+ [U OK?]
    -> ask
+ [LEAVE]
    -> leave

=== ask ===
ummm... #speaker:Me #portrait:dia_avatar_peoplegirl
is everything ok? #speaker:Me #portrait:dia_avatar_peoplegirl
~ playEmote("talk")
I can't find any good bread recipe! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
what? #speaker:Me #portrait:dia_avatar_peoplegirl
every site I enter has a whole life story! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
I don't care about your stupid farm! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
I don't care about your stupid mom! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
JUST TELL ME THE INGRIDIENTS! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
... #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
+ [BREAD]
    -> bread
+ [TODO]
    -> todo
+ [BYE]
    -> leave


=== bread ===
what type of bread are you looking to make #speaker:Me #portrait:dia_avatar_peoplegirl
~ playEmote("talk")
a super regular one! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
just a simple Cranberry-Orange Star Bread with homemade cranberry sauce  #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
homegrown oranges and vegan eggs replacement! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
there's egg in bread? #speaker:Me #portrait:dia_avatar_peoplegirl
~ playEmote("talk")
WELL I DON'T FUCKING KNOW I CAN'T FIND A RECIPE! #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
soooooo..... #speaker:Me #portrait:dia_avatar_peoplegirl
+ [TODO]
 ->todo
 
+[BYE]
-> leave

    
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////ADD STORY///////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
-> END
=== todo ===
what can I even do here? #speaker:Me #portrait:dia_avatar_peoplegirl
~ playEmote("talk")
well you can search for things #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
like what? #speaker:Me #portrait:dia_avatar_peoplegirl
~ playEmote("talk")
everything #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
everything? #speaker:Me #portrait:dia_avatar_peoplegirl
that's too much. #speaker:Me #portrait:dia_avatar_peoplegirl
where do I even start? #speaker:Me #portrait:dia_avatar_peoplegirl
~ playEmote("talk")
well, what interests you? #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
~ playEmote("idle")
??? #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
+[BULB]
    ->bulb

+[GAMES]
    ->games

+[CONFIDENCE]
    ->confidence

=== bulb ===
I would really like to know how to change a light bulb #speaker:Me #portrait:dia_avatar_peoplegirl
what. #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
how old are you? #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
you know something? I don't care. #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
There's a little post next to one of the houses here. #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
It can take you to a site where there are useful lifehacks. #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
Now leave me alone I <b>NEED</b> to find this bread #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
-> END
=== games ===

-> END
=== confidence ===

-> END

=== leave ===
I don't wanna deal with this right now #speaker:Me #portrait:dia_avatar_peoplegirl
-> END

