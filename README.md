Inventory System with Unity
![Screenshot 2024-02-19 165147](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/289da35f-ec52-4971-9712-a2884fc2fa41)
![Screenshot 2024-02-19 165107](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/f190a658-81a8-4499-b2a2-dcd04e8a0230)
![Screenshot 2024-02-19 165042](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/4e6af53a-1eb1-4110-9a17-8e63b6717c67)
![Screenshot 2024-02-19 165009](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/9b6cdead-e00f-4962-902f-152fa7eba373)
![Screenshot 2024-02-19 164942](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/ea1a37ea-b7c9-442f-88cd-8f248509679b)
![Screenshot 2024-02-19 164850](https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/96643d96-096b-485a-a881-d2f72308ede3)


https://github.com/YashDevLogs/Inventory-Shop/assets/91522919/6932b133-a25e-4f61-b54d-b95572e1b2c4


Overview

This Unity project implements a comprehensive inventory system for managing items in a game environment. The system includes features such as buying and selling items, displaying item descriptions, managing inventory weight, and handling coin transactions.

Key Features

Scriptable Objects: Items in the game are represented as scriptable objects (ItemScriptableObject). This allows for easy creation, customization, and management of item data directly from the Unity Editor.

Enums: The project utilizes enums (ItemType, ItemRarity) to categorize items and define their rarity levels. This makes it easier to organize and classify items based on their properties.

UI Integration: The user interface (UI) elements are dynamically updated to reflect changes in the inventory, coin balance, and item descriptions. This provides a seamless user experience when interacting with the inventory system.

Event Listeners: Event listeners are used to trigger actions such as opening and closing panels (MenuButtons), buying items (ShopManager), and displaying item descriptions (ItemIconDisplay). This enhances the interactivity and responsiveness of the inventory system.

Weight Management: The inventory manager (InventoryManager) keeps track of the weight of items in the inventory and prevents adding items beyond a certain weight limit. This adds a realistic constraint to inventory management in the game.


How to Use


Setup: Import the project into Unity.
Create Items: Define new items using scriptable objects and customize their properties such as name, icon, description, buying price, selling price, rarity, quantity, and weight.
UI Integration: Set up UI elements to display inventory, coin balance, item descriptions, and other relevant information. Attach event listeners to UI buttons to enable user interactions.
Gameplay Integration: Integrate the inventory system into your game by linking item interactions to gameplay mechanics such as buying/selling items, managing inventory weight, and using items in the game world.



Contributing


Contributions are welcome! If you have any suggestions, bug fixes, or feature enhancements, feel free to submit a pull request or open an issue.

