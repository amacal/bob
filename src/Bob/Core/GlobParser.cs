using System;
using System.Collections.Generic;

namespace Bob.Core
{
    public class GlobParser
    {
        private readonly List<GlobNode> nodes;
        private readonly string text;
        private int position;
        private bool? rooted;

        public GlobParser(string text)
        {
            this.text = text;
            this.nodes = new List<GlobNode>();
        }

        public GlobNode[] Parse()
        {
            this.position = 0;
            this.nodes.Clear();

            while (this.text.Length > this.position)
            {
                if (this.rooted == null)
                {
                    if (this.ParseRoot() == true)
                    {
                        this.rooted = true;
                    }
                }

                if (this.ParseContent() == true)
                {
                    if (this.rooted == true)
                    {
                        this.rooted = false;
                    }
                }
            }

            return this.nodes.ToArray();
        }

        private bool ParseRoot()
        {
            return this.ParseDrive() 
                || this.ParseNetwork();
        }

        private bool ParseContent()
        {
            return this.ParseLiteral()
                || this.ParseQuestionMark()
                || this.ParseSingleStar()
                || this.ParseDoubleStar()
                || this.ParseSeparator();
        }

        private bool ParseDrive()
        {
            return false;
        }

        private bool ParseNetwork()
        {
            return false;
        }

        private bool ParseLiteral()
        {
            char[] special = { '/', '\\', '?', '*' };

            if (this.text.Length > this.position)
            {
                if (Array.IndexOf(special, this.text[this.position]) == -1)
                {
                    this.nodes.Add(new GlobLiteral(this.text[this.position]));
                    this.position++;

                    return true;
                }
            }

            return false;
        }

        private bool ParseSeparator()
        {
            if (this.text.Length > this.position)
            {
                if (this.text[this.position] == '/' || this.text[this.position] == '\\')
                {
                    this.nodes.Add(new GlobSeparator());
                    this.position++;

                    return true;
                }
            }

            return false;
        }

        private bool ParseSingleStar()
        {
            if (this.text.Length > this.position)
            {
                if (this.text[this.position] == '*')
                {
                    if (this.text.Length > this.position + 1)
                    {
                        if (this.text[this.position + 1] != '*')
                        {
                            this.nodes.Add(new GlobSingleStar());
                            this.position++;

                            return true;
                        }
                    }
                    else
                    {
                        this.nodes.Add(new GlobSingleStar());
                        this.position++;

                        return true;
                    }
                }
            }

            return false;
        }

        private bool ParseDoubleStar()
        {
            if (this.text.Length > this.position)
            {
                if (this.text[this.position] == '*')
                {
                    if (this.text.Length > this.position + 1)
                    {
                        if (this.text[this.position + 1] == '*')
                        {
                            this.nodes.Add(new GlobDoubleStar());
                            this.position += 2;

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool ParseQuestionMark()
        {
            if (this.text.Length > this.position)
            {
                if (this.text[this.position] == '?')
                {
                    this.nodes.Add(new GlobQuestionMark());
                    this.position++;

                    return true;
                }
            }

            return false;
        }
    }
}
