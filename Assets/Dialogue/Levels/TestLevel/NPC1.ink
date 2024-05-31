INCLUDE ../../globals.ink

{ NPC_ANS_01 == "": -> main | -> already_chose }

=== main ===
You know the moon? #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
Some people think the moon landing was fake. #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
What do you think? #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
    + [real]
    ~ MOON_ANS = true
        Yeah of course it was real #speaker:Player #portrait:dia_avatar_peoplegirl
        -> chosen("We have evidance of the moon landing")
    + [fake]
    ~ MOON_ANS = false
    No way it's real. #speaker:Player #portrait:dia_avatar_peoplegirl
    How does the flag fly when there's no wind on the moon? #speaker:Player #portrait:dia_avatar_peoplegirl
        -> chosen("Bro no wind no landing bro")
    + [super fake]
    ~ MOON_ANS = false
    Wait. #speaker:Player #portrait:dia_avatar_peoplegirl
    You belive in the moon?? #speaker:Player #portrait:dia_avatar_peoplegirl
        -> chosen("The moon is fake. We live in a simulation")
        

=== already_chose ===
I did some more research. #speaker:Player #portrait:dia_avatar_peoplegirl
And what do you think now? #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
    + [real]
    ~ MOON_ANS = true
        Yeah of course it was real #speaker:Player #portrait:dia_avatar_peoplegirl
        -> chosen("We have evidance of the moon landing")
    + [fake]
    ~ MOON_ANS = false
    No way it's real. #speaker:Player #portrait:dia_avatar_peoplegirl
    How does the flag fly when there's no wind on the moon? #speaker:Player #portrait:dia_avatar_peoplegirl
        -> chosen("Bro no wind no landing bro")
    + [super fake]
    ~ MOON_ANS = false
    Wait. #speaker:Player #portrait:dia_avatar_peoplegirl
    You belive in the moon?? #speaker:Player #portrait:dia_avatar_peoplegirl
        -> chosen("The moon is fake. We live in a simulation")
        
        
=== chosen(opinion) ===
~ NPC_ANS_01 = opinion
Whatever you think. #speaker:Stephanie #portrait:dia_avatar_formalwoman_01
-> END