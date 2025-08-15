<p align="center">
<img src="./screenshot.png">
</p>

# Chess.NET

`Chess.NET` is a local two-player chess game, written in C#/WPF. It aims to provide a clean architecture and design according to the Model-View-ViewModel (MVVM) architectural pattern. Notable features are:

* Supports all standard rules of a chess game, including castling, en passant and promotion.
* Supports hints for chess piece movements, allowing only valid movements to be selected.
* Supports a wide range of animations using the features of WPF.
* Supports window resizing for arbitrary display resolutions.
* Provides a fully immutable implementation of the chess game model.
* Provides an undo command to restore previous chess game states.
* Provides a full code documentation.

---

## New in This Version — Chess960 Support

The project now includes full support for **Chess960** (Fischer Random Chess), with the following additions:

* **New Rulebook implementation** for Chess960, randomizing the back rank while ensuring:
  - Bishops are on opposite-colored squares.
  - The king is placed between the two rooks.
  - both sides have the same starting positions
* **Menu dropdown option** for switching game mode between standard rules and Chess960 then automatically restarting the game.
