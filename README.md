Inventory System with Unity


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

