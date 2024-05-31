INCLUDE ../../globals.ink

{ NPC_ANS_02 == "": -> main | -> already_chose }

=== main ===
Going on an adventure? #speaker:Randy #portrait:dia_avatar_adventuregirl
Be sure to keep your friends close  #speaker:Randy #portrait:dia_avatar_adventuregirl
<color=\#ab0b00>And your enemies closer</color>  #speaker:Randy #portrait:dia_avatar_adventuregirl
What do ya wanna talk about? #speaker:Randy #portrait:dia_avatar_adventuregirl
    + [clothes]
        What's  up with these clothes? #speaker:Player #portrait:dia_avatar_peoplegirl
Oh it's from a game I like #speaker:Randy #portrait:dia_avatar_adventuregirl
Always thought it was weird how short the pants were. #speaker:Randy #portrait:dia_avatar_adventuregirl
What do you mean? #speaker:Player #portrait:dia_avatar_peoplegirl
She's gonna get all scratched up! #speaker:Randy #portrait:dia_avatar_adventuregirl
-> chosen("I can look however I'd like!")
        
    + [gun]
    No way it's real. #speaker:Player #portrait:dia_avatar_peoplegirl
    Nah bro it's just a prop lol #speaker:Randy #portrait:dia_avatar_adventuregirl
        -> chosen("Placeholder2")
    + [help]
   Could I get some help from you? #speaker:Player #portrait:dia_avatar_peoplegirl
   Sure just holler when you need me! #speaker:Randy #portrait:dia_avatar_adventuregirl
        -> chosen("I have people helping me!")


=== already_chose ===
I have some more questions. #speaker:Player #portrait:dia_avatar_peoplegirl
What's up? #speaker:Randy #portrait:dia_avatar_adventuregirl
      + [clothes]
        What's  up with these clothes? #speaker:Player #portrait:dia_avatar_peoplegirl
Oh it's from a game I like #speaker:Randy #portrait:dia_avatar_adventuregirl
Always thought it was weird how short the pants were. #speaker:Randy #portrait:dia_avatar_adventuregirl
What do you mean? #speaker:Player #portrait:dia_avatar_peoplegirl
She's gonna get all scratched up! #speaker:Randy #portrait:dia_avatar_adventuregirl
-> chosen("I can look however I'd like!")
        
    + [gun]
    No way it's real. #speaker:Player #portrait:dia_avatar_peoplegirl
    Nah bro it's just a prop lol #speaker:Randy #portrait:dia_avatar_adventuregirl
        -> chosen("Placeholder2")
    + [help]
   Could I get some help from you? #speaker:Player #portrait:dia_avatar_peoplegirl
   Sure just holler when you need me! #speaker:Randy #portrait:dia_avatar_adventuregirl
        -> chosen("I have people helping me!")
        
        
=== chosen(opinion) ===
~ NPC_ANS_02 = opinion
Ciao! #speaker:Randy #portrait:dia_avatar_adventuregirl
-> END