A narrative-rich, console-based dungeon crawler written in C#. You play as a mysterious hero exploring dungeons, facing terrifying creatures, and uncovering cryptic lore within a cursed town and its surrounding darkness.

Features
Turn-Based Combat: Engage in fast and heavy attacks, use items, or flee from powerful foes.

Quest System: Accept and complete quests to earn gold and lore from the townsfolk.

Dynamic Dungeon Generation: Random rooms with multi-enemy encounters, mini-bosses, and treasures.

Player Progression: Equip weapons, use healing items, gain XP, and unlock secrets as you survive.

Multiple Game States: Navigate between resting, exploring dungeons, and visiting town services like the market, church, or bar.

Final Boss Fight: A phased battle with the terrifying Lord Malgar, who changes strategy mid-fight.

Narrative Elements: Discover mysterious hints and strange relics through rest events.

Architecture & Design Patterns
Factory Pattern: RoomFactory creates different types of dungeon rooms.

State Pattern: IState and its implementations (TownState, DungeonState, RestState) handle game modes.

Strategy-like Behavior: IEncounter enables various combat encounter strategies (single, multi-enemy).

Abstract Base Class: Quest class allows creation of specific quests
