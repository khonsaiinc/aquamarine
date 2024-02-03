-> main
=== main ===
Hungry? #character:>w0 #image:girl_speaking
So, what do you want to eat?#character:>w0 #image:girl_question
    +[Spicy prawn soup]
        -> chosen("Spicy prawn soup")
    +[Fried rice]
        -> chosen("Fried rice")
    +[Papaya salad]
        -> chosen("Papaya salad")

=== chosen(Food) ===
I want to eat {Food}.#character:player #image:player_speaking
Even though I'm not sure if it will make it maybe not delicious.#character:>w0 #image:girl_idle
But I'll try. hehehe~~~~#character:>w0 #image:girl_fighting
Thank you.#character:player #image:player_smile
Your welcome.#character:>w0 #image:girl_smile
-> END
