Oh this house is so beautiful!

 * [What are you doing?]->WhatAreYouDoing
 * [What are you doing at my house?]->WhatAreYouDoingAtMyHouse
 ===WhatAreYouDoing
 Well..., I was just passing by here on my way to work. The house was so beautiful that I stopped to check it out.-0
 *[Only the house but what to see?]->OnlyTheHouse
 *[I see there are houses around.]->ISeeThere
    ===OnlyTheHouse
    You know, for the workers here, having a place to go back and relax is very precious. We almost never dreamed of a house as big as this.-2
        *[Is the income that low here?]->IsTheIncome
        *[...]->Silent
            ===IsTheIncome
            You say this, I find it difficult to answer, haha. However, it was originally just the countryside. Having a job is also a good thing. Looks like you're new here, right?-3
            *[Um that's right. I'm new here]->UmThatRight
            *[No, I've been here a long time.]->END
                ===UmThatRight
                Oh, what made you choose to stay here? I'm curious too.-3
                *[I just travel]->IJustTravel
                *[I find it peaceful here]->IFindItPeaceful
                *[I didn't know this place was so poor]->IDidntKnowThis
                    ===IJustTravel
                    That's it. I hope you feel comfortable here! Although this place is not as well off as the city of Barosexia which is the citadel of our country Fontaine. However, you see that this place is much more peaceful and the air is much fresher.-0->DONE
                    ===IFindItPeaceful
                    Ah so that's it. You said it right. Although I am not very happy or proud of the income and standard of living here, I am always proud that Sandra is the most peaceful place in Fontaine.-0->DONE
                    ===IDidntKnowThis
                    You make me feel pretty sad, young friend. However, we can't help but admit our shortcomings, right haha. Hopefully, you will not feel too disappointed while staying here.-2->DONE
                ===NoIveBeen
                Oh is that true? I heard from a few neighbors that you just moved here.-0
                *[...]->END
                
            ===Silent
            I say what makes you okay, young friend. What do you seem to be thinking about?-0
            *[It seems that life here is difficult]->ItSeem
            *[No, I'm not]->NoImNot
                ===NoImNot
                Oh yeah, sorry I'm curious. If you're busy, I won't bother you anymore.-0->DONE
                ===ItSeem
                Yes, it's a little difficult, but it's okay, sometimes life needs a little challenge to be interesting, right?-0->DONE
    ===ISeeThere
    Haha, I mean home to live in. As you can see it's all apartment buildings here, there's a house across the city that's also a place for the nobility. However, something happened that made them decide not to stay there anymore.-3
    *[What happened there?]->WhatHappen
    *[Doesn't anyone take over that house?]->DoesntAnyone
        ===WhatHappen
        I'm not sure. Just know that there is a noble family, a lot of thieves often sneak in there to steal. However, when they came out, they weren't mad and speechless. Many people say that there are ghosts there. I shudder to mention this!-3
        *[Is it believable?]->IsItBelievable
        *[It sounds scary]->ItsSoundScary
            ===IsItBelievable
            Oh young kid! You can experience that house for yourself! You really don't know what god is. If something happens, don't say I didn't tell you in advance. Leave me alone, it's annoying.-1->DONE
            ===ItsSoundScary
            That's right, there is a Vietnamese proverb "There are abstinences that are good"! You have to be careful with that house!-0->DONE
            
        ===DoesntAnyone
        Don't ask such silly questions! Surely no one would dare to take over that place. You know that house has been abandoned for nearly 100 years now. I was also told that every time someone loitered near that house, laughter could be heard and the atmosphere around it became strangely dark.-1->DONE
===WhatAreYouDoingAtMyHouse
Oh, is this your home? I'm so sorry. Really admire that! It's been a long time since I've seen such a big house in the suburbs of Sandra! Don't worry, I'll be right away!-3 -> DONE
-> END
