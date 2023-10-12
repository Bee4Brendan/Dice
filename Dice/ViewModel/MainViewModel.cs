
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dice.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel() 
    {
        
    }

    readonly Random dice = new();
    int dice1;
    int dice2;
    int dice3;
    int count = 1;

    [ObservableProperty]
    string text;

    [ObservableProperty]
    string diceText;

    [ObservableProperty]
    string info = "                " +
        "Score 15 to WIN\n " +
        "  TWO OF A KIND = 2 Point Bonus\n" +
        "THREE OF A KIND = 6 Point Bonus";

    [ObservableProperty]
    string result;

    [RelayCommand]
    void Roll()
    {
        int bonus = 0;

        // add our item
        Text = "Rolling Dice...";

        dice1 = dice.Next(1, 7);
        dice2 = dice.Next(1, 7);
        dice3 = dice.Next(1, 7);

        DiceText = $"Roll {count++}:\t\t{dice1}\t{dice2}\t{dice3}";

        Text = "Dice Rolled!";

        // 3 of a kind!
        if(dice1 == dice2 && dice2 == dice3)
        {
            bonus += 6;
        }
        // 2 of a kind!
        
        if(dice1 == dice2 || dice2 == dice3 || dice1 == dice3)
        {
            bonus += 2;
        }

        int score = dice1 + dice2 + dice3 + bonus;

        Text = $"{score}";
        Result = score >= 15 ? "YOU WIN!" : "YOU LOSE.";
    }
}
