﻿using tabuleiro;
using Pecas_xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);


                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }

                Console.Clear();
                Tela.imprimirPartida(partida);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }
    }
}