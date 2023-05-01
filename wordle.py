import csv
import random
import tkinter as tk

target_word = None
list_of_guesses = []
max_guesses = 6

def startGame():
    global target_word
    print("Start game!")
    
    # pick and set target word
    ans_csv_reader = list(map(lambda x: x.strip(), open('valid_answers.csv').readlines()))
    target_word = random.choice(ans_csv_reader)
    
     # set user guesses text box
    user_guesses.pack()
    
    # guess button
    guess_button = tk.Button(root, text="GUESS", command=score_guess)
    guess_button.pack()
    
    
def score_guess():
    # user guesses text box
    user_guess = user_guesses.get()

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