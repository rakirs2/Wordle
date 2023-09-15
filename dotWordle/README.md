# WordleBot
Should solve wordle in easy and hard mode under 6 guesses

## General Algorithm

1. Take list of words stored locally
2. Generate a list of best guesses
    a. Initially, guess every word, see how many words that guess can remove
3. Repeat. Must solve for every set in 6 guesses

## How to calculate guesses