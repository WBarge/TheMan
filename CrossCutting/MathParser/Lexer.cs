using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MathParser
{
    internal class TokenParser
    {
        private readonly OrderedDictionary<Tokens, string> _tokens;
        private readonly OrderedDictionary<Tokens, MatchCollection> _regExMatchCollection;
        private string _inputString;
        private int _index;
        private int _customFunctionIndex;

        /// <summary>
        /// 
        /// </summary>
        public enum Tokens
        {
            Undefined = 0, // Undefined Token
            Whitespace = 1, // Whitespace Characters
            Newline = 2, // Newline Characters
            Function = 3, // Function
            Sqrt = 4, // Square Root
            Sin = 5, // Sin
            Cos = 6, // Cos
            Abs = 7, // Abs
            Tan = 8, // Tan
            Variable = 9, // Variables
            Float = 10, // Floating Point Numbers
            Integer = 11, // Integer Numbers
            Lparen = 12, //  Left Parenthesis
            Rparen = 13, //  Right Parenthesis
            Exponent = 14, // Exponent
            Modulus = 15, //  Modulus Operator
            Multiply = 16, //  Multiplication Operator
            Divide = 17, //  Division Operator
            Add = 18, //  Add Operator
            Subtract = 19, //  Subtract Operator
            Log = 20,   // Log Operator
            LogN = 21,  // Natural Log Operator
        }

        /// <summary>
        /// Sets the input string.
        /// </summary>
        /// <value>
        /// The input string.
        /// </value>
        public string InputString
        {
            set
            {
                _inputString = value;
                PrepareRegex();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenParser"/> class.
        /// </summary>
        public TokenParser()
        {
            _tokens = new OrderedDictionary<Tokens, string>();
            _regExMatchCollection = new OrderedDictionary<Tokens, MatchCollection>();
            _index = 0;
            _inputString = string.Empty;
            _customFunctionIndex = 100;
            
            _tokens.Add(Tokens.Whitespace, "[ \\t]+");
            _tokens.Add(Tokens.Newline, "[\\r\\n]+");
            _tokens.Add(Tokens.Function, "func([a-zA-Z_][a-zA-Z0-9_]*)\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.LogN, "[Ll][Oo][Gg][Nn]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Sqrt, "[Ss][Qq][Rr][Tt]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Sin, "[Ss][Ii][Nn]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Cos, "[Cc][Oo][Ss]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Tan, "[Tt][Aa][Nn]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Abs, "[Aa][Bb][Ss]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Log, "[Ll][Oo][Gg]\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Add(Tokens.Variable, "[a-zA-Z_][a-zA-Z0-9_]*");
            _tokens.Add(Tokens.Float, "([0-9]+)?\\.+[0-9]+");
            _tokens.Add(Tokens.Integer, "[0-9]+");
            _tokens.Add(Tokens.Lparen, "\\(");
            _tokens.Add(Tokens.Rparen, "\\)");
            _tokens.Add(Tokens.Exponent, "\\^");
            _tokens.Add(Tokens.Modulus, "\\%");
            _tokens.Add(Tokens.Multiply, "\\*");
            _tokens.Add(Tokens.Divide, "\\/");
            _tokens.Add(Tokens.Add, "\\+");
            _tokens.Add(Tokens.Subtract, "\\-");
        }

        /// <summary>
        /// Registers the custom function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        public void RegisterCustomFunction(string functionName)
        {
            var sb = new StringBuilder();

            foreach (char c in functionName)
            {
                sb.Append("[");
                sb.Append(char.ToUpper(c));
                sb.Append(char.ToLower(c));
                sb.Append("]");
            }
            sb.Append("\\(((?<BR>\\()|(?<-BR>\\))|[^()]*)+\\)");
            _tokens.Insert(4, (Tokens)_customFunctionIndex, sb.ToString());
            _customFunctionIndex++;
        }

        /// <summary>
        /// Prepares the regex.
        /// </summary>
        private void PrepareRegex()
        {
            _regExMatchCollection.Clear();
            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                _regExMatchCollection.Add(pair.Key, Regex.Matches(_inputString, pair.Value));
            }
        }

        /// <summary>
        /// Resets the parser.
        /// </summary>
        public void ResetParser()
        {
            _index = 0;
            _inputString = string.Empty;
            _regExMatchCollection.Clear();
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns></returns>
        public Token GetToken()
        {
            if (_index >= _inputString.Length)
                return null;

            foreach (KeyValuePair<Tokens, MatchCollection> pair in _regExMatchCollection)
            {
                foreach (Match match in pair.Value)
                {
                    if (match.Index == _index)
                    {
                        _index += match.Length;
                        return new Token(pair.Key, match.Value);
                    }

                    if (match.Index > _index)
                    {
                        break;
                    }
                }
            }
            _index++;
            return new Token(Tokens.Undefined, string.Empty);
        }

        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        public PeekToken Peek()
        {
            return Peek(new PeekToken(_index, new Token(Tokens.Undefined, string.Empty)));
        }

        /// <summary>
        /// Peeks the specified peek token.
        /// </summary>
        /// <param name="peekToken">The peek token.</param>
        /// <returns></returns>
        public PeekToken Peek(PeekToken peekToken)
        {
            int oldIndex = _index;

            _index = peekToken.TokenIndex;

            if (_index >= _inputString.Length)
            {
                _index = oldIndex;
                return null;
            }

            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                var r = new Regex(pair.Value);
                Match m = r.Match(_inputString, _index);

                if (m.Success && m.Index == _index)
                {
                    _index += m.Length;
                    var pt = new PeekToken(_index, new Token(pair.Key, m.Value));
                    _index = oldIndex;
                    return pt;
                }
            }
            var pt2 = new PeekToken(_index + 1, new Token(Tokens.Undefined, string.Empty));
            _index = oldIndex;
            return pt2;
        }
    }

    internal class PeekToken
    {
        /// <summary>
        /// Gets or sets the index of the token.
        /// </summary>
        /// <value>
        /// The index of the token.
        /// </value>
        public int TokenIndex { get; set; }

        /// <summary>
        /// Gets or sets the token peek.
        /// </summary>
        /// <value>
        /// The token peek.
        /// </value>
        public Token TokenPeek { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PeekToken"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public PeekToken(int index, Token value)
        {
            TokenIndex = index;
            TokenPeek = value;
        }
    }

    internal class Token
    {
        /// <summary>
        /// Gets or sets the name of the token.
        /// </summary>
        /// <value>
        /// The name of the token.
        /// </value>
        public TokenParser.Tokens TokenName { get; set; }

        /// <summary>
        /// Gets or sets the token value.
        /// </summary>
        /// <value>
        /// The token value.
        /// </value>
        public string TokenValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Token(TokenParser.Tokens name, string value)
        {
            TokenName = name;
            TokenValue = value;
        }
    }
}

