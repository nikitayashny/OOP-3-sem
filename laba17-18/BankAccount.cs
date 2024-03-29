﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18
{
    public class BankAccount
    {
        public string id;
        internal double amountOfMoney;
        public string name;

        public static int cardCount = 0;
        public string status;

        List<Card> cards = new List<Card>();

        public BankAccount(string id, string name)
        {
            this.id = id;
            amountOfMoney = 0;
            status = "unblocked";
            this.name = name;
        }
        public void CreateCreditDollarCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new CreditDollarFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void CreateCreditBitcoinCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new CreditBitcoinFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }

        public void CreateDebitBitcoinCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new DebitBitcoinFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }
        public void CreateDebitDollarCard(string name)
        {
            if (status != "blocked")
            {
                cards.Add(new Card(new DebitDollarFactory(), name));
                cardCount++;
            }
            else Console.WriteLine("Bank account blocked");
        }
        public void AddMoney(double money)
        {
            if (status != "blocked")
                this.amountOfMoney += money;
            else Console.WriteLine("Bank account blocked");
        }
        public void RemoveMoney(double money)
        {
            if (status != "blocked")
            {
                if (this.amountOfMoney >= money)
                {
                    this.amountOfMoney -= money;
                }
                else Console.WriteLine("Insufficient funds");
            }
            else Console.WriteLine("Bank account blocked");
        }
        public void Blocked()
        {
            if (status == "unblocked")
            {
                status = "blocked";
                Console.WriteLine("The bank account has been successfully blocked");
            }
            else Console.WriteLine("The bank account was not unblocked");
        }
        public override string ToString()
        {
            return "Name: " + this.name + " # Id: " + this.id + " # Money:" + this.amountOfMoney;
        }

        public void WriteInfoCard()
        {
            int i = 1;
            foreach (Card card in cards)
            {
                Console.WriteLine($"============ Card {i} ==============");
                card.GetCarrencyCard();
                card.GetTypeCard();
            }
        }
    }
}