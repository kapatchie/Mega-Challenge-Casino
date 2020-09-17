using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mega_Challenge_Casino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        int playerMoney;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                playerMoney = 100;
                moneyLabel.Text = playerMoney.ToString();
                SelectImages(generateRandom());
            }
        }

        public void leverButton_Click(object sender, EventArgs e)
        {
            int[] randomNumber = generateRandom();
            playerMoney = int.Parse(moneyLabel.Text);
            if (playerMoney > 0)
            {
                if (checkIfAnyInput())
                {
                    int betAmount = checkInput(betTextBox.Text);
                    SelectImages(randomNumber);
                    if (CheckMatches(randomNumber)[0] > 0 || CheckMatches(randomNumber)[1] == 3)
                    {
                        int winnings = calculateResults((betAmount), CheckMatches(randomNumber));
                        resultLabel.Text = string.Format("You Won {0:C}", winnings);
                        playerMoney += winnings;
                        moneyLabel.Text = playerMoney.ToString();
                    }
                    else
                    {
                        resultLabel.Text = string.Format("You Lost {0:C}", betAmount);
                        playerMoney -= betAmount;
                        moneyLabel.Text = playerMoney.ToString();
                    }
                }
            }
        }

        private int[] generateRandom()
        {
            int[] randomNumbers = new int[] { random.Next(0, 11), random.Next(0, 11), random.Next(0, 11) };
            return randomNumbers;
        }
        private void SelectImages(int[] randomNumbers)
        {
                string[] imagesUrl = new string[] { @"~/Images/Bar.png",@"~/Images/Cherry.png",@"~/Images/Seven.png", @"~/Images/Bell.png",  
                @"~/Images/Clover.png", @"~/Images/Diamond.png", @"~/Images/HorseShoe.png", @"~/Images/Lemon.png", 
                @"~/Images/Orange.png", @"~/Images/Plum.png",  @"~/Images/Strawberry.png", 
                @"~/Images/Watermellon.png"};

            leftImageReel.ImageUrl = imagesUrl[randomNumbers[0]];
            middleImageReel.ImageUrl = imagesUrl[randomNumbers[1]];
            rightImageReel.ImageUrl = imagesUrl[randomNumbers[2]];
        }
        private bool checkIfAnyInput()
        {
            if (betTextBox.Text.Trim().Length > 0) return true;

            return false;
        }
        private int checkInput(string betAmount)
        {
            if (!int.TryParse(betTextBox.Text, out int betAmountValue)) return 0; ;
            return betAmountValue;
        }
        private int[] CheckMatches(int[] randomNumbers)
        {
            int cherryCount = 0; int sevenCount = 0;

            if (!randomNumbers.Contains(0))
            {
                for (int i = 0; i < randomNumbers.Length; i++)
                {
                    if (randomNumbers[i] == 1) cherryCount += 1;
                    if (randomNumbers[i] == 2) sevenCount += 1;
                }           
            }
            return new int[] {cherryCount,sevenCount};
        } 
       
        private int calculateResults(int betAmount, int[] matches)
        {         
            if (matches[1] == 3) betAmount *= 100;
            if (matches[0] == 1) betAmount *= 2;
            if (matches[0] == 2) betAmount *= 3;
            if (matches[0] == 3) betAmount *= 4;

            return betAmount;
        }
    }
}