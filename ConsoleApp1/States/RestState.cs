using Game.Items;
using Game.Root;

namespace Game.States
{
    public class RestState : IState
    {
        private readonly GameManager manager;
        private static readonly List<string> hints = new List<string>
        {

            "You are resting in the Manor. After some wandering you stumble into a basement. You find a septic tank with a child’s head. Mauled, eyeless, earless. You feel cold. You decide to ignore it.",
            "In an abandoned room behind the chapel, you find a massive metal contraption. When you stand close, it reacts to your presence. You feel like you’ve been inside it before. You decide to ignore it.",
            "Behind torn curtains in the attic, you find a display box with two bloodied wings. They match your body eerily well. You feel like you're missing something. You decide to ignore it.",
            "You find a journal page: 'His screams were divine. His tears, liquid power.' It's dated two years before you woke up.",
            "A maid mumbles in her sleep: 'He said the angel begged for death…'. You leave before she wakes.",
            "A half-burned drawing shows a family: a boy, a man in robes, and… you. There's a nail through your face.",
            "You open a music box. The melody makes your body tremble. You feel memories you can’t remember.",
            "You find a broken syringe labeled 'Essence Repression Formula'. There’s blood on it. You decide to ignore it",
            "The Father walks by your door at night. He stops. You hear him whisper, '...he’s waking up again…'",
            "A hidden room behind the chapel contains jars. Dozens. Each holds floating organs, labeled in shaky handwriting: 'Vocal cords, v3', 'Left lung (screamer)', 'Angel’s ovary?'. You decide to ignore it.",
            "In a hidden drawer, you find feathers burned into ashes. They crumble when touched.",
            "The cellar reeks of rot. You hear someone sobbing. When you open the door, it stops.",
            "Your dreams are different now. You hear chains. Screaming...'...he silences what he cannot tame...'."
        };
        private static int restCount = 0;
        private static Random random = new Random();
        public RestState(GameManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            restCount++;

            // Heal fully
            manager.Player.HP = manager.Player.MaxHP;
            Console.WriteLine("You rest and regain full HP.");

            string hint = hints[random.Next(hints.Count)];
            Console.WriteLine($"\nSome time passes: {hint}");

            if (restCount == 5)
            {
                var dagger = new DarkDagger();
                manager.Player.Bag.AddItem(dagger);
                Console.WriteLine("\nYou discovered a hidden relic beneath your bed: the Dark Dagger. It pulses with forbidden purpose.");
            }

            if (restCount == 10)
            {
                manager.Player.Betray = true;
                Console.WriteLine("\nA quiet realization settles over you. You are being watched — and it’s not by the gods.");
            }
        }
    }
}
