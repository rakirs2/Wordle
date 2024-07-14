# WordleBot

Should solve wordle in easy and hard mode under 6 guesses for all valid answers (and maybe all valid words)

## General Algorithm

1. Take list of words stored locally
2. Generate a list of best guesses
   a. Initially, guess every word, see how many words that guess can remove
3. Repeat. Must solve for every set in 6 guesses

## How to calculate guesses

### Sets of words

1. The expected answers list (about 2k words) stored in valid_answers.csv
1. The list of all possible answers. We use the list of all possible answers

### Play against random computer

1. Computer picks a random word
1. User inputs data per guess and the computer spits out good words

### Types of guesses

Valid guess: a guess that can be accepted.
Good guess: a guess that uses all of the information gathered.
Bad guess: guess that does not use all of the information gathered but is still valid.
Best guess: valid guess that reduces the amount of possible guesses with the knowledge at the time of guessing.

### Data utilization

1. Empty letters or whites/blacks. These are the easiest. Any word with a single letter must be removed
1. Green letters. Every word that does not have the corresponding green is not good.
1. Yellow Letters. At this point, we've used the data from all of the greens. For every remaining word, if we remove the
   known greens from the hashmap of characters, any word without the given character in the quantity needed is bad.

### Determining best guess

1. We assume that our goal is to reduce remaining words to 1.
1. Technically, any word can be correct. So the complete answer would be:
    1. For each remaining good word
        1. Keep track of words eliminated
        1. Assume every goodguess (excluding it) is an answer
        1. In each scenario, count the number of words eliminated under those assumptions
            1. Best guess is the word that removes the most words
            1. Best likely guess is the word that removes the most likely words
            1. Worst guess is the word that removes the least words
            1. Worst likely guess is the word that removes the least likely words

## Testing/success

- [ ] Easy Wordle solver on likely words solves 100% averaging less than 4
- [ ] Easy Wordle solver on all words solves 100%
- [ ] Hard Wordle solver solves on all likely words averaging less than 5.
- [ ] Wordle solver solves on all words.