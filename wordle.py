import csv
from collections import defaultdict
from collections import Counter
import random
import tkinter as tk

target_word = None
list_of_guesses = []
max_guesses = 6

def startGame():
    # pick and set target word
    global target_word
    ans_csv_reader = list(map(lambda x: x.strip(), open('valid_answers.csv').readlines()))
    target_word = random.choice(ans_csv_reader)

    start_button.destroy()
     # set user guesses text box
    user_guesses.pack()
    
    # guess button
    guess_button = tk.Button(root, text="GUESS", command=score_guess)
    guess_button.pack()


    
def score_guess():
    # user guesses text box
    user_guess = user_guesses.get('1.0', 'end')

    results = defaultdict()

    letterCounts = Counter(target_word)

    for i in range(5):
        if user_guess[i] == target_word[i]:
            results[i] = 'g'
            letterCounts[i] -=1
    
    for i in range(5):
        #check if in results
        if i not in results:
            #
            if user_guess[i] in letterCounts and  letterCounts[i]>0:
                results[i] = 'y'
                letterCounts[i] -=1


if __name__ == '__main__':
    root = tk.Tk()
    
    # app window title
    root.title("WORDLE")
    
    # set app window size
    root.geometry("500x500")
    
    # app title
    titleLabel = tk.Label(root, text = "Click START to play WORDLE!",
									font = ('Helvetica', 12))
    titleLabel.pack()
    
    # start button
    start_button = tk.Button(root, text="START", command=startGame)
    start_button.pack()

    # user guesses
    user_guesses = tk.Text(root, height=5, width=30)

    # start
    root.mainloop()