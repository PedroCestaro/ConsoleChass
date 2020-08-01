using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int coluna)
        {
            this.linhas = linhas;
            this.colunas = coluna;
            pecas = new Peca[linhas, coluna];
        }


        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos) /*Faz sentido, é necessário uma posição no tabuleiro, e está recebendo inteira, não separada como até então*/
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos); /*Utiliza o método para validação, já criado*/
                    return  peca(pos) != null;
        }
        public void colocarPeca(Peca p, Posicao pos)
        {         
            if(existePeca(pos))/* se a função retorna true*/
            {
                throw new TabuleiroException("Já existe peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna >= colunas) { return false; }
            return true;
        }


        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Invalida, seu burro");
            }

        }






    }
}
