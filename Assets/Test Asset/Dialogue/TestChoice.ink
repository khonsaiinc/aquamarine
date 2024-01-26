-> Testline
=== Testline ===
1 #speaker:girl #portait:girl_speaking
2
3

-> main
=== main ===

Foods Menu
    +[Spicy prawn soup]
        -> chosen("Spicy prawn soup")
    +[Fried rice]
        -> chosen("Fried rice")
    +[Papaya salad]
        -> chosen("Papaya salad")

=== chosen(Food) ===

Chosen {Food}!

-> Testline2
=== Testline2 ===

3
2
1
-> END
