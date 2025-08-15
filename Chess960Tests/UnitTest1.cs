using Xunit;
using System.Linq;
using Chess.Model.Rule;
using Chess.Model.Game;
using Chess.Model.Piece;

namespace Chess960Tests
{
    public class UnitTest1
    {
        [Fact]
        public void InitialPosition_ShouldBeValidChess960()
        {
            // Arrange
            var rulebook = new Chess960Rulebook();
            ChessGame game = rulebook.CreateGame();

            // Act
            var whiteBackRank = game.Board.GetPieces(Color.White)
                .Where(p => p.Position.Row == 0)
                .OrderBy(p => p.Position.Column)
                .Select(p => p.Piece)
                .ToList();

            // Assert
            // 1. There must be exactly one king, two rooks, two bishops, one queen, two knights
            Assert.Equal(8, whiteBackRank.Count);
            Assert.Single(whiteBackRank.OfType<King>());
            Assert.Equal(2, whiteBackRank.OfType<Rook>().Count());
            Assert.Equal(2, whiteBackRank.OfType<Bishop>().Count());
            Assert.Single(whiteBackRank.OfType<Queen>());
            Assert.Equal(2, whiteBackRank.OfType<Knight>().Count());

            // 2. Bishops must be on opposite colors
            var bishopColumns = whiteBackRank
                .Select((piece, idx) => (piece, idx))
                .Where(x => x.piece is Bishop)
                .Select(x => x.idx)
                .ToArray();
            Assert.Equal(2, bishopColumns.Length);
            Assert.NotEqual(bishopColumns[0] % 2, bishopColumns[1] % 2);

            // 3. King must be between the two rooks
            int kingCol = whiteBackRank.FindIndex(p => p is King);
            var rookCols = whiteBackRank
                .Select((piece, idx) => (piece, idx))
                .Where(x => x.piece is Rook)
                .Select(x => x.idx)
                .OrderBy(i => i)
                .ToArray();
            Assert.True(rookCols[0] < kingCol && kingCol < rookCols[1]);

            // 4. Both colors must have the same setup
            var blackBackRank = game.Board.GetPieces(Color.Black)
                .Where(p => p.Position.Row == 7)
                .OrderBy(p => p.Position.Column)
                .Select(p => p.Piece)
                .ToList();

            Assert.Equal(whiteBackRank.Count, blackBackRank.Count);
            for (int i = 0; i < whiteBackRank.Count; i++)
            {
                Assert.Equal(whiteBackRank[i].GetType(), blackBackRank[i].GetType());
            }
        }
    }
}