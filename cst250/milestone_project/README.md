# Cover Sheet

### Class: CST-250
### Professor: Jason Jazzar
### Author: Phillip Ball

---

|Milestone| Page Link | Video Link |
| :--------:  | ----------- | -------------- |
| 1 | [Here](#milestone-one) | None |
| 2/3 | [Here](#milestone-twothree) | None |
| 4 | [Here](#milestone-four) | None |
| 5 | [Here](#milestone-five) | [Here](https://www.youtube.com/watch?v=YiPxlsjcNbw) |
| 6 | [Here](#milestone-six) | None |


# Milestone One

***This milestone shows the board functionally displaying, where the 0's are empty squares with no neighboring bombs, X's are bombs, and every numbered square shows how many bombs are near their center from a 3 by 3 area. The screenshots display the changeability in the board and how it is generated.***

## UML Diagram
![uml](docs/uml.png)

## Screenshots

**10 by 10 with a 10% chance to spawn a bomb**

![ss1](docs/10x10_10chance.png)

**10 by 10 with a 30% chance to spawn a bomb**

![ss2](docs/10x10_30chance.png)

**20 by 20 with a 10% chance to spawn a bomb**

![ss3](docs/20x20_10chance.png)

**20 by 20 with a 30% chance to spawn a bomb**

![ss4](docs/20x20_30chance.png)

**20 by 20 with a 1% chance to spawn a bomb**

![ss5](docs/20x20_1chance.png)

# Milestone Two/Three

[Back to Top](#cover-sheet)

***I Saw Milestone two and mainly read that it needs to be an interactive version for the game thinking that it should be a playable console minesweeper. Afterwards I just began programming it inside of the program.cs and ended up adding a bunch of functions to make the full minesweeper game. This led me to adding the recursion and after viewing milestone three, I see that I messed up. I will just put them both into this page of the markdown, if I should do something else, please let me know. Thanks!***

## UML Diagram
![uml2](docs/uml2.png)

## Flow Chart
![FlowChart](docs/FlowChart.png)

## Screenshots

**Initial pop-up Screen**

![2ss1](docs/initial_screen.png)

**After the Row and Column inputs are received ( 0, 0), on the game board the question mark that was once there is now a 1. This screenshot displays the base input functionality.**

![2ss2](docs/first_user_inputs.png)

**After entering the inputs ( 5, 5), we can see that the whole board opened correctly from the recursion, this was due to ( 5, 5) being a blank square which allowed for the recursion to start working. This screenshot displays the recursion functionality.**

![2ss3](docs/revealing_5_5.png)

**After seeing that ( 1, 0) had a bunch of ones nearby it's cell, it was safe to assume that ( 1, 0) was a bomb and I chose to mark it with an X. This screenshot displays the marking functionality.**

![2ss4](docs/marked_1_0.png)

**After seeing that ( 1, 0) was a bomb, there was a good opportunity to showcase the endgame functionality, which displays the full board uncovered. This works the same for the win game function with just the "You hit a bomb :(" message saying "You beat the game!" instead. This screenshot shows the endgame functionality.**

![2ss5](docs/hitting_1_0.png)

**After losing or winning the game the user can just hit 1 on their keyboard to play again. This screenshot just demonstrates that a new board with new hidden cells shows up when a 1 is entered.**

![2ss6](docs/selecting_play_again.png)

# Milestone Four

[Back to Top](#cover-sheet)

## Screenshots

**Initial select difficulty screen**

![4ss1](docs/gui_select_difficulty.png)

**10 x 10 Button grid displayed after the play game click**

![4ss2](docs/gui_after_play_game.png)

**Button click functionality displayed, increasing per click on button**

![4ss3](docs/gui_after_clicks.png)

**15 x 15 to demonstrate that the grid can be dynamically sized**

![4ss4](docs/gui_15x15_demonstration.png)

## UI Wireframe

![4wireframe](docs/wireframe.png)

# Milestone Five

[Back to Top](#cover-sheet)

## Screenshots

**Initial Screen**

![m5_1](docs/m5_1.png)

**10 x 10 Board Start**

![m5_2](docs/m5_2.png)

**10 x 10 Board Completion**

![m5_3](docs/m5_3.png)

**10 x 10 Board Fail**

![m5_4](docs/m5_4.png)

# Milestone Six

[Back to Top](#cover-sheet)

## Screenshots

**Initial Screen**

![m6_1](docs/m6_1.png)

**10 x 10 Board Completion**

![m6_2](docs/m6_2.png)

**Leaderboard so far, after running the game a few times**

![m6_3](docs/m6_3.png)

**Selecting 5x5 to demonstrate the difference on completion**

![m6_4](docs/m6_4.png)

**Leader board after a few 5x5 completions, with the score being sorted descending, with information on the difficulty, map size, and date completed**

![m6_5](docs/m6_5.png)

## Other

**This is how I generate the score given to the player, subtracting 100 by difficulty is needed because the difficulty is easier the higher it is**

```
return Math.Round((100 - difficulty) * size / seconds * 100, 2);
```