namespace FizzleTD.Core;

public record Data
{

    public record Window
    {
        public static string Title { get; set; } = "FizzleTD!";
        public static int Width { get; set; } = 1600;
        public static int Height { get; set; } = 900;
    }
    public record Game
    {
        public enum SCENES : sbyte
        {
            MENU = 0x1,
            GAME = 0x2,
            TRANSITION = 0x4,
        }

    };

}
