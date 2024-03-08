
https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/b9d1b580-f90b-48fb-a850-0956a55a9f77




Overview

This Unity project implements a comprehensive inventory system for managing items in a game environment. The system includes features such as buying and selling items, displaying item descriptions, managing inventory weight, handling coin transactions, implementing sound effects, and gathering random resources.

Key Features

Scriptable Objects: Items in the game are represented as scriptable objects (ItemScriptableObject). This allows for easy creation, customization, and management of item data directly from the Unity Editor.

Enums: The project utilizes enums (ItemType, ItemRarity) to categorize items and define their rarity levels. This makes it easier to organize and classify items based on their properties.

UI Integration: The user interface (UI) elements are dynamically updated to reflect changes in the inventory, coin balance, and item descriptions. This provides a seamless user experience when interacting with the inventory system.

Event Listeners: Event listeners are used to trigger actions such as opening and closing panels (MenuButtons), buying items (ShopManager), and displaying item descriptions (ItemIconDisplay). This enhances the interactivity and responsiveness of the inventory system.

Weight Management: The inventory manager (InventoryManager) keeps track of the weight of items in the inventory and prevents adding items beyond a certain weight limit. This adds a realistic constraint to inventory management in the game.

Sound System: Sound effects are implemented using a SoundScriptableObject, which contains a list of sounds mapped to specific actions or events in the game. This enhances the immersion and audio feedback for player interactions.

Resource Gathering: The game includes a gather resources button that gathers random resources when clicked. The rarity of the gathered items is proportional to the cumulative value of the player's inventory, adding an element of chance and progression to resource acquisition.

Observer Pattern Implementation: The project utilizes the observer pattern to handle buy and sell logic. Event controllers and event services are used to manage event invocation, addition, and removal of listeners, enhancing the extensibility and modularity of the codebase.

How to Use

Setup: Import the project into Unity.
Create Items: Define new items using scriptable objects and customize their properties such as name, icon, description, buying price, selling price, rarity, quantity, and weight.
UI Integration: Set up UI elements to display inventory, coin balance, item descriptions, and other relevant information. Attach event listeners to UI buttons to enable user interactions.
Gameplay Integration: Integrate the inventory system into your game by linking item interactions to gameplay mechanics such as buying/selling items, managing inventory weight, and using items in the game world. Utilize the gather resources button to collect random resources and enhance the player's experience.

Contributing

Contributions are welcome! If you have any suggestions, bug fixes, or feature enhancements, feel free to submit a pull request or open an issue. Your feedback and contributions help improve the project for everyone.


Inventory System with Unity
![Screenshot 2024-02-19 165147](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/289da35f-ec52-4971-9712-a2884fc2fa41)
![Screenshot 2024-02-19 164942](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/ea1a37ea-b7c9-442f-88cd-8f248509679b)
![Screenshot 2024-02-19 164850](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/96643d96-096b-485a-a881-d2f72308ede3)


