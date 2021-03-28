using System;
using Xunit;
using TicTacToe.BLL;
using System.Collections.Generic;
using FluentAssertions;

namespace TicTacToe.Tests
{
    public class CheckAccessCellTests
    {
        public static IEnumerable<object[]> PositiveData =>
        new List<object[]>
        {
            new object[] { 1, new char[3, 3] { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } } },
            new object[] { 9, new char[3, 3] { { '\0', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } } },
        };

        public static IEnumerable<object[]> NegativeData =>
        new List<object[]>
        {
            new object[] { 1, new char[3, 3] { { 'X', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', '\0' } } },
            new object[] { 9, new char[3, 3] { { 'X', '\0', '\0' }, { '\0', '\0', '\0' }, { '\0', '\0', 'O' } } },
        };

        [Theory]
        [MemberData(nameof(PositiveData))]
        public void CheckAccessCellPositiveTest(int number, char[,] gameField)
        {
            var game = new TicTacToe.BLL.TicTacToe();
            game.SetGameField(gameField);
            var cellPosition = game.FindCellPositionByNumber(number);
            game.CheckAccessCellByPosition(cellPosition).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(NegativeData))]
        public void CheckAccessCellNegativeTest(int number, char[,] gameField)
        {
            var game = new TicTacToe.BLL.TicTacToe();
            game.SetGameField(gameField);
            var cellPosition = game.FindCellPositionByNumber(number);
            game.CheckAccessCellByPosition(cellPosition).Should().BeFalse();
        }
    }
}
