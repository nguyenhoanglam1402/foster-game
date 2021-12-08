Hi! Is there anything I can help?

 * [That's right.] -> yes_i_am
 * [Where are you going?]
 * [I would like to inquire a bit.]
 * [No, goodbye.]
 
 ===yes_i_am
    Tell me, what do you want to help? I'm busy.-4
     * [Can you show me the way to 37 Celsius cafe?]->37celsius
     * [Can you show me the way to Durin's Haunted House?]->DONE
     * [Can you direct me to the Soul Bar?]->DONE
    ===37celsius
    Ah, that cafe, it's located in the south of the city. You see the Trump building over there? That's right, that house looks weird and disgusting. The cafe you need is close by.
        * [Hateful?]->hateful
        * [You don't seem to like that building, do you?]->END
            ==hateful
            Still have to ask? That heterogeneous house looks out of place in this beautiful Sandra city. You know, that used to be my family's residence. The rich bastard bought that land with a high price. Then, my landowner decided to break the contract and kick my whole family out into the street.
                * [That's an exaggeration]->thats_an_exaggeration
                * [You deserve this!]->DONE
                    ===thats_an_exaggeration
                    Even so, you know, the thing that saddens me the most is not being able to buy a house for my parent. They have worked hard for entire their lives, and now they have no place to rest. I plan to go to Basorexia city next month to get a job so that I can buy a decent house for them.
                    * [Good luck!]->good_luck
                        ===good_luck
                        Thank you very much, (laugh). It's also thanks to you that I can feel my heart for so many years. May the deity God of Wind bless you on your journey!
                            *[God of Wind?]->god_of_wind
                            ===god_of_wind
                            It is the god who represents the wind of will and faith of this Sandra land. She overthrew the yoke of Andrew Clan, the forerunner of  Dvalin Clan, and ushered in a time of freedom in the land of Sandra. You may not know that Sandra is named after this god, demonstrating Sandra's protection for this land.
                                * [May God of Wind always bless you.]->may_god_of_wind
                                    ===may_god_of_wind
                                    Sure, my friend, I wish you all the best->DONE
                    ===you_deserve_this
                    
    -> END
