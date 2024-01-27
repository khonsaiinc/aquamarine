-> main
=== main ===
Hungry? #speaker:>w0 #portait:girl_speaking
So, what do you want to eat?#speaker:>w0 #portait:girl_question
    +[Spicy prawn soup]
        -> chosen("Spicy prawn soup")
    +[Fried rice]
        -> chosen("Fried rice")
    +[Papaya salad]
        -> chosen("Papaya salad")

=== chosen(Food) ===
I want to eat {Food}.#speaker:player #portait:player_speaking
Even though I'm not sure if it will make it maybe not delicious.#speaker:>w0 #portait:girl_idle
But I'll try. hehehe~~~~#speaker:>w0 #portait:girl_fighting
Thank you.#speaker:player #portait:player_smile
Your welcome.#speaker:>w0 #portait:girl_smile
-> END
