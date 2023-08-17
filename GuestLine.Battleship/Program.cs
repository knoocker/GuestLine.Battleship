// See https://aka.ms/new-console-template for more information
using GuestLine.Battleship.BattleshipLogic.Game;


Game game = new Game();
Console.WriteLine(game.Interact("r"));
while (true)
{
    string s = Console.ReadLine();
    if (s.ToLower()=="q")
    {
        return;
    }
    Console.WriteLine(game.Interact(s));
}
