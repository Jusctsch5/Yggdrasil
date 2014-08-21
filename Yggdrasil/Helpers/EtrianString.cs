﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Yggdrasil.Helpers
{
    public class EtrianString
    {
        #region European/American character map

        static readonly Dictionary<ushort, char> characterMapEnglish = new Dictionary<ushort, char>()
        {
            { 0x0001, ' ' },
            { 0x0002, '!' },
            { 0x0003, '"' },
            { 0x0004, '#' },
            { 0x0005, '$' },
            { 0x0006, '%' },
            { 0x0007, '&' },
            { 0x0008, '\'' },
            { 0x0009, '(' },
            { 0x000A, ')' },
            { 0x000B, '*' },
            { 0x000C, '+' },
            { 0x000D, ',' },
            { 0x000E, '-' },
            { 0x000F, '.' },
            { 0x0010, '/' },
            { 0x0011, '0' },
            { 0x0012, '1' },
            { 0x0013, '2' },
            { 0x0014, '3' },
            { 0x0015, '4' },
            { 0x0016, '5' },
            { 0x0017, '6' },
            { 0x0018, '7' },
            { 0x0019, '8' },
            { 0x001A, '9' },
            { 0x001B, ':' },
            { 0x001C, ';' },
            { 0x001D, '<' },
            { 0x001E, '=' },
            { 0x001F, '>' },
            { 0x0020, '?' },
            { 0x0021, '@' },
            { 0x0022, 'A' },
            { 0x0023, 'B' },
            { 0x0024, 'C' },
            { 0x0025, 'D' },
            { 0x0026, 'E' },
            { 0x0027, 'F' },
            { 0x0028, 'G' },
            { 0x0029, 'H' },
            { 0x002A, 'I' },
            { 0x002B, 'J' },
            { 0x002C, 'K' },
            { 0x002D, 'L' },
            { 0x002E, 'M' },
            { 0x002F, 'N' },
            { 0x0030, 'O' },
            { 0x0031, 'P' },
            { 0x0032, 'Q' },
            { 0x0033, 'R' },
            { 0x0034, 'S' },
            { 0x0035, 'T' },
            { 0x0036, 'U' },
            { 0x0037, 'V' },
            { 0x0038, 'W' },
            { 0x0039, 'X' },
            { 0x003A, 'Y' },
            { 0x003B, 'Z' },
            { 0x003C, '[' },
            { 0x003D, '\\' },
            { 0x003E, ']' },
            { 0x003F, '^' },
            { 0x0040, '_' },
            { 0x0041, '´' },
            { 0x0042, 'a' },
            { 0x0043, 'b' },
            { 0x0044, 'c' },
            { 0x0045, 'd' },
            { 0x0046, 'e' },
            { 0x0047, 'f' },
            { 0x0048, 'g' },
            { 0x0049, 'h' },
            { 0x004A, 'i' },
            { 0x004B, 'j' },
            { 0x004C, 'k' },
            { 0x004D, 'l' },
            { 0x004E, 'm' },
            { 0x004F, 'n' },
            { 0x0050, 'o' },
            { 0x0051, 'p' },
            { 0x0052, 'q' },
            { 0x0053, 'r' },
            { 0x0054, 's' },
            { 0x0055, 't' },
            { 0x0056, 'u' },
            { 0x0057, 'v' },
            { 0x0058, 'w' },
            { 0x0059, 'x' },
            { 0x005A, 'y' },
            { 0x005B, 'z' },
            { 0x005C, '{' },
            { 0x005D, '|' },
            { 0x005E, '}' },
            { 0x005F, '~' },
            { 0x0060, '€' },
            { 0x0061, '․' },
            { 0x0062, '„' },
            { 0x0063, '…' },
            { 0x0064, '‸' },
            { 0x0065, 'Œ' },
            { 0x0066, '′' },
            { 0x0067, '‵' },
            { 0x0068, '″' },
            { 0x0069, '‶' },
            { 0x006A, '•' },
            { 0x006B, '‴' },
            { 0x006C, '™' },
            { 0x006D, '›' },
            { 0x006E, 'œ' },
            { 0x006F, '¡' },
            { 0x0070, '¢' },
            { 0x0071, '£' },
            { 0x0072, '¨' },
            { 0x0073, '©' },
            { 0x0074, '®' },
            { 0x0075, '°' },
            { 0x0076, '±' },
            { 0x0077, '´' },
            { 0x0078, '·' },
            { 0x0079, '¿' },
            { 0x007A, 'À' },
            { 0x007B, 'Á' },
            { 0x007C, 'Â' },
            { 0x007D, 'Ã' },
            { 0x007E, 'Ä' },
            { 0x007F, 'Å' },
            { 0x0080, 'Æ' },
            { 0x0081, 'Ç' },
            { 0x0082, 'È' },
            { 0x0083, 'É' },
            { 0x0084, 'Ê' },
            { 0x0085, 'Ë' },
            { 0x0086, 'Ì' },
            { 0x0087, 'Í' },
            { 0x0088, 'Î' },
            { 0x0089, 'Ï' },
            { 0x008A, 'Ð' },
            { 0x008B, 'Ñ' },
            { 0x008C, 'Ò' },
            { 0x008D, 'Ó' },
            { 0x008E, 'Ô' },
            { 0x008F, 'Õ' },
            { 0x0090, 'Ö' },
            { 0x0091, '×' },
            { 0x0092, 'Ø' },
            { 0x0093, 'Ù' },
            { 0x0094, 'Ú' },
            { 0x0095, 'Û' },
            { 0x0096, 'Ü' },
            { 0x0097, 'Ý' },
            { 0x0098, 'ß' },
            { 0x0099, 'à' },
            { 0x009A, 'á' },
            { 0x009B, 'â' },
            { 0x009C, 'ã' },
            { 0x009D, 'ä' },
            { 0x009E, 'å' },
            { 0x009F, 'æ' },
            { 0x00A0, 'ç' },
            { 0x00A1, 'è' },
            { 0x00A2, 'é' },
            { 0x00A3, 'ê' },
            { 0x00A4, 'ë' },
            { 0x00A5, 'ì' },
            { 0x00A6, 'í' },
            { 0x00A7, 'î' },
            { 0x00A8, 'ï' },
            { 0x00A9, 'ð' },
            { 0x00AA, 'ñ' },
            { 0x00AB, 'ò' },
            { 0x00AC, 'ó' },
            { 0x00AD, 'ô' },
            { 0x00AE, 'õ' },
            { 0x00AF, 'ö' },
            { 0x00B0, '÷' },
            { 0x00B1, 'ø' },
            { 0x00B2, 'ù' },
            { 0x00B3, 'ú' },
            { 0x00B4, 'û' },
            { 0x00B5, 'ü' },
            { 0x00B6, 'ý' },
            { 0x00B7, '→' },
            { 0x00B8, '←' },
            { 0x00B9, '↑' },
            { 0x00BA, '↓' },
            { 0x00BB, '«' },
            { 0x00BC, '»' },
            { 0x00BD, 'ª' },
            { 0x00BE, 'º' },
            { 0x00BF, 'ͤ' },
            { 0x00C0, 'ͬ' },
        };

        #endregion

        #region Japanese character map

        static readonly Dictionary<ushort, char> characterMapJapanese = new Dictionary<ushort, char>()
        {
            { 0x0001, ' ' },
            { 0x0002, '、' },
            { 0x0003, '。' },
            { 0x0004, '，' },
            { 0x0005, '．' },
            { 0x0006, '・' },
            { 0x0007, '：' },
            { 0x0008, '；' },
            { 0x0009, '？' },
            { 0x000A, '！' },
            { 0x000B, '゛' },
            { 0x000C, '゜' },
            { 0x000D, '´' },
            { 0x000E, '｀' },
            { 0x000F, '¨' },
            { 0x0010, '＾' },
            { 0x0011, '￣' },
            { 0x0012, '＿' },
            { 0x0013, '々' },
            { 0x0014, 'ー' },
            { 0x0015, '―' },
            { 0x0016, '／' },
            { 0x0017, '\\' },
            { 0x0018, '～' },
            { 0x0019, '｜' },
            { 0x001A, '…' },
            { 0x001B, '‘' },
            { 0x001C, '’' },
            { 0x001D, '“' },
            { 0x001E, '”' },
            { 0x001F, '（' },
            { 0x0020, '）' },
            { 0x0021, '［' },
            { 0x0022, '］' },
            { 0x0023, '「' },
            { 0x0024, '」' },
            { 0x0025, '『' },
            { 0x0026, '』' },
            { 0x0027, '【' },
            { 0x0028, '】' },
            { 0x0029, '＋' },
            { 0x002A, '−' },
            { 0x002B, '±' },
            { 0x002C, '×' },
            { 0x002D, '÷' },
            { 0x002E, '＝' },
            { 0x002F, '＜' },
            { 0x0030, '＞' },
            { 0x0031, '≦' },
            { 0x0032, '≧' },
            { 0x0033, '￥' },
            { 0x0034, '＄' },
            { 0x0035, '％' },
            { 0x0036, '＃' },
            { 0x0037, '＆' },
            { 0x0038, '＊' },
            { 0x0039, '＠' },
            { 0x003A, '☆' },
            { 0x003B, '★' },
            { 0x003C, '○' },
            { 0x003D, '●' },
            { 0x003E, '◎' },
            { 0x003F, '◇' },
            { 0x0040, '◆' },
            { 0x0041, '□' },
            { 0x0042, '■' },
            { 0x0043, '△' },
            { 0x0044, '▲' },
            { 0x0045, '▽' },
            { 0x0046, '▼' },
            { 0x0047, '※' },
            { 0x0048, '→' },
            { 0x0049, '←' },
            { 0x004A, '↑' },
            { 0x004B, '↓' },
            { 0x004C, '０' },
            { 0x004D, '１' },
            { 0x004E, '２' },
            { 0x004F, '３' },
            { 0x0050, '４' },
            { 0x0051, '５' },
            { 0x0052, '６' },
            { 0x0053, '７' },
            { 0x0054, '８' },
            { 0x0055, '９' },
            { 0x0056, 'Ａ' },
            { 0x0057, 'Ｂ' },
            { 0x0058, 'Ｃ' },
            { 0x0059, 'Ｄ' },
            { 0x005A, 'Ｅ' },
            { 0x005B, 'Ｆ' },
            { 0x005C, 'Ｇ' },
            { 0x005D, 'Ｈ' },
            { 0x005E, 'Ｉ' },
            { 0x005F, 'Ｊ' },
            { 0x0060, 'Ｋ' },
            { 0x0061, 'Ｌ' },
            { 0x0062, 'Ｍ' },
            { 0x0063, 'Ｎ' },
            { 0x0064, 'Ｏ' },
            { 0x0065, 'Ｐ' },
            { 0x0066, 'Ｑ' },
            { 0x0067, 'Ｒ' },
            { 0x0068, 'Ｓ' },
            { 0x0069, 'Ｔ' },
            { 0x006A, 'Ｕ' },
            { 0x006B, 'Ｖ' },
            { 0x006C, 'Ｗ' },
            { 0x006D, 'Ｘ' },
            { 0x006E, 'Ｙ' },
            { 0x006F, 'Ｚ' },
            { 0x0070, 'ａ' },
            { 0x0071, 'ｂ' },
            { 0x0072, 'ｃ' },
            { 0x0073, 'ｄ' },
            { 0x0074, 'ｅ' },
            { 0x0075, 'ｆ' },
            { 0x0076, 'ｇ' },
            { 0x0077, 'ｈ' },
            { 0x0078, 'ｉ' },
            { 0x0079, 'ｊ' },
            { 0x007A, 'ｋ' },
            { 0x007B, 'ｌ' },
            { 0x007C, 'ｍ' },
            { 0x007D, 'ｎ' },
            { 0x007E, 'ｏ' },
            { 0x007F, 'ｐ' },
            { 0x0080, 'ｑ' },
            { 0x0081, 'ｒ' },
            { 0x0082, 'ｓ' },
            { 0x0083, 'ｔ' },
            { 0x0084, 'ｕ' },
            { 0x0085, 'ｖ' },
            { 0x0086, 'ｗ' },
            { 0x0087, 'ｘ' },
            { 0x0088, 'ｙ' },
            { 0x0089, 'ｚ' },
            { 0x008A, 'ぁ' },
            { 0x008B, 'あ' },
            { 0x008C, 'ぃ' },
            { 0x008D, 'い' },
            { 0x008E, 'ぅ' },
            { 0x008F, 'う' },
            { 0x0090, 'ぇ' },
            { 0x0091, 'え' },
            { 0x0092, 'ぉ' },
            { 0x0093, 'お' },
            { 0x0094, 'か' },
            { 0x0095, 'が' },
            { 0x0096, 'き' },
            { 0x0097, 'ぎ' },
            { 0x0098, 'く' },
            { 0x0099, 'ぐ' },
            { 0x009A, 'け' },
            { 0x009B, 'げ' },
            { 0x009C, 'こ' },
            { 0x009D, 'ご' },
            { 0x009E, 'さ' },
            { 0x009F, 'ざ' },
            { 0x00A0, 'し' },
            { 0x00A1, 'じ' },
            { 0x00A2, 'す' },
            { 0x00A3, 'ず' },
            { 0x00A4, 'せ' },
            { 0x00A5, 'ぜ' },
            { 0x00A6, 'そ' },
            { 0x00A7, 'ぞ' },
            { 0x00A8, 'た' },
            { 0x00A9, 'だ' },
            { 0x00AA, 'ち' },
            { 0x00AB, 'ぢ' },
            { 0x00AC, 'っ' },
            { 0x00AD, 'つ' },
            { 0x00AE, 'づ' },
            { 0x00AF, 'て' },
            { 0x00B0, 'で' },
            { 0x00B1, 'と' },
            { 0x00B2, 'ど' },
            { 0x00B3, 'な' },
            { 0x00B4, 'に' },
            { 0x00B5, 'ぬ' },
            { 0x00B6, 'ね' },
            { 0x00B7, 'の' },
            { 0x00B8, 'は' },
            { 0x00B9, 'ば' },
            { 0x00BA, 'ぱ' },
            { 0x00BB, 'ひ' },
            { 0x00BC, 'び' },
            { 0x00BD, 'ぴ' },
            { 0x00BE, 'ふ' },
            { 0x00BF, 'ぶ' },
            { 0x00C0, 'ぷ' },
            { 0x00C1, 'へ' },
            { 0x00C2, 'べ' },
            { 0x00C3, 'ぺ' },
            { 0x00C4, 'ほ' },
            { 0x00C5, 'ぼ' },
            { 0x00C6, 'ぽ' },
            { 0x00C7, 'ま' },
            { 0x00C8, 'み' },
            { 0x00C9, 'む' },
            { 0x00CA, 'め' },
            { 0x00CB, 'も' },
            { 0x00CC, 'ゃ' },
            { 0x00CD, 'や' },
            { 0x00CE, 'ゅ' },
            { 0x00CF, 'ゆ' },
            { 0x00D0, 'ょ' },
            { 0x00D1, 'よ' },
            { 0x00D2, 'ら' },
            { 0x00D3, 'り' },
            { 0x00D4, 'る' },
            { 0x00D5, 'れ' },
            { 0x00D6, 'ろ' },
            { 0x00D7, 'わ' },
            { 0x00D8, 'を' },
            { 0x00D9, 'ん' },
            { 0x00DA, 'ァ' },
            { 0x00DB, 'ア' },
            { 0x00DC, 'ィ' },
            { 0x00DD, 'イ' },
            { 0x00DE, 'ゥ' },
            { 0x00DF, 'ウ' },
            { 0x00E0, 'ェ' },
            { 0x00E1, 'エ' },
            { 0x00E2, 'ォ' },
            { 0x00E3, 'オ' },
            { 0x00E4, 'カ' },
            { 0x00E5, 'ガ' },
            { 0x00E6, 'キ' },
            { 0x00E7, 'ギ' },
            { 0x00E8, 'ク' },
            { 0x00E9, 'グ' },
            { 0x00EA, 'ケ' },
            { 0x00EB, 'ゲ' },
            { 0x00EC, 'コ' },
            { 0x00ED, 'ゴ' },
            { 0x00EE, 'サ' },
            { 0x00EF, 'ザ' },
            { 0x00F0, 'シ' },
            { 0x00F1, 'ジ' },
            { 0x00F2, 'ス' },
            { 0x00F3, 'ズ' },
            { 0x00F4, 'セ' },
            { 0x00F5, 'ゼ' },
            { 0x00F6, 'ソ' },
            { 0x00F7, 'ゾ' },
            { 0x00F8, 'タ' },
            { 0x00F9, 'ダ' },
            { 0x00FA, 'チ' },
            { 0x00FB, 'ヂ' },
            { 0x00FC, 'ッ' },
            { 0x00FD, 'ツ' },
            { 0x00FE, 'ヅ' },
            { 0x00FF, 'テ' },
            { 0x0100, 'デ' },
            { 0x0101, 'ト' },
            { 0x0102, 'ド' },
            { 0x0103, 'ナ' },
            { 0x0104, 'ニ' },
            { 0x0105, 'ヌ' },
            { 0x0106, 'ネ' },
            { 0x0107, 'ノ' },
            { 0x0108, 'ハ' },
            { 0x0109, 'バ' },
            { 0x010A, 'パ' },
            { 0x010B, 'ヒ' },
            { 0x010C, 'ビ' },
            { 0x010D, 'ピ' },
            { 0x010E, 'フ' },
            { 0x010F, 'ブ' },
            { 0x0110, 'プ' },
            { 0x0111, 'ヘ' },
            { 0x0112, 'ベ' },
            { 0x0113, 'ペ' },
            { 0x0114, 'ホ' },
            { 0x0115, 'ボ' },
            { 0x0116, 'ポ' },
            { 0x0117, 'マ' },
            { 0x0118, 'ミ' },
            { 0x0119, 'ム' },
            { 0x011A, 'メ' },
            { 0x011B, 'モ' },
            { 0x011C, 'ャ' },
            { 0x011D, 'ヤ' },
            { 0x011E, 'ュ' },
            { 0x011F, 'ユ' },
            { 0x0120, 'ョ' },
            { 0x0121, 'ヨ' },
            { 0x0122, 'ラ' },
            { 0x0123, 'リ' },
            { 0x0124, 'ル' },
            { 0x0125, 'レ' },
            { 0x0126, 'ロ' },
            { 0x0127, 'ワ' },
            { 0x0128, 'ヲ' },
            { 0x0129, 'ン' },
            { 0x012A, 'ヴ' },
            { 0x012B, 'Ⅱ' },
            { 0x012C, 'Ⅲ' },

            { 0x012D, '哀' },
            { 0x012E, '愛' },
            { 0x012F, '悪' },
            { 0x0130, '圧' },
            { 0x0131, '扱' },
            { 0x0132, '安' },
            { 0x0133, '暗' },
            { 0x0134, '闇' },
            { 0x0135, '以' },
            { 0x0136, '位' },
            { 0x0137, '依' },
            { 0x0138, '偉' },
            { 0x0139, '囲' },
            { 0x013A, '威' },
            { 0x013B, '意' },
            { 0x013C, '易' },
            { 0x013D, '為' },
            { 0x013E, '畏' },
            { 0x013F, '異' },
            { 0x0140, '移' },
            { 0x0141, '維' },
            { 0x0142, '衣' },
            { 0x0143, '謂' },
            { 0x0144, '違' },
            { 0x0145, '遺' },
            { 0x0146, '医' },
            { 0x0147, '井' },
            { 0x0148, '域' },
            { 0x0149, '育' },
            { 0x014A, '一' },
            { 0x014B, '溢' },
            { 0x014C, '稲' },
            { 0x014D, '印' },
            { 0x014E, '員' },
            { 0x014F, '因' },
            { 0x0150, '引' },
            { 0x0151, '飲' },
            { 0x0152, '院' },
            { 0x0153, '陰' },
            { 0x0154, '隠' },
            { 0x0155, '右' },
            { 0x0156, '烏' },
            { 0x0157, '羽' },
            { 0x0158, '雨' },
            { 0x0159, '嘘' },
            { 0x015A, '唄' },
            { 0x015B, '噂' },
            { 0x015C, '運' },
            { 0x015D, '雲' },
            { 0x015E, '餌' },
            { 0x015F, '影' },
            { 0x0160, '映' },
            { 0x0161, '栄' },
            { 0x0162, '泳' },
            { 0x0163, '英' },
            { 0x0164, '衛' },
            { 0x0165, '鋭' },
            { 0x0166, '液' },
            { 0x0167, '益' },
            { 0x0168, '越' },
            { 0x0169, '円' },
            { 0x016A, '援' },
            { 0x016B, '沿' },
            { 0x016C, '炎' },
            { 0x016D, '焔' },
            { 0x016E, '猿' },
            { 0x016F, '遠' },
            { 0x0170, '汚' },
            { 0x0171, '奥' },
            { 0x0172, '応' },
            { 0x0173, '横' },
            { 0x0174, '殴' },
            { 0x0175, '王' },
            { 0x0176, '黄' },
            { 0x0177, '屋' },
            { 0x0178, '億' },
            { 0x0179, '乙' },
            { 0x017A, '俺' },
            { 0x017B, '卸' },
            { 0x017C, '音' },
            { 0x017D, '下' },
            { 0x017E, '化' },
            { 0x017F, '何' },
            { 0x0180, '価' },
            { 0x0181, '加' },
            { 0x0182, '可' },
            { 0x0183, '夏' },
            { 0x0184, '家' },
            { 0x0185, '果' },
            { 0x0186, '歌' },
            { 0x0187, '河' },
            { 0x0188, '火' },
            { 0x0189, '禍' },
            { 0x018A, '花' },
            { 0x018B, '華' },
            { 0x018C, '過' },
            { 0x018D, '我' },
            { 0x018E, '牙' },
            { 0x018F, '画' },
            { 0x0190, '芽' },
            { 0x0191, '駕' },
            { 0x0192, '介' },
            { 0x0193, '会' },
            { 0x0194, '解' },
            { 0x0195, '回' },
            { 0x0196, '塊' },
            { 0x0197, '壊' },
            { 0x0198, '快' },
            { 0x0199, '怪' },
            { 0x019A, '悔' },
            { 0x019B, '戒' },
            { 0x019C, '改' },
            { 0x019D, '械' },
            { 0x019E, '海' },
            { 0x019F, '界' },
            { 0x01A0, '皆' },
            { 0x01A1, '絵' },
            { 0x01A2, '開' },
            { 0x01A3, '階' },
            { 0x01A4, '外' },
            { 0x01A5, '害' },
            { 0x01A6, '涯' },
            { 0x01A7, '蓋' },
            { 0x01A8, '街' },
            { 0x01A9, '鎧' },
            { 0x01AA, '嚇' },
            { 0x01AB, '各' },
            { 0x01AC, '格' },
            { 0x01AD, '核' },
            { 0x01AE, '殻' },
            { 0x01AF, '獲' },
            { 0x01B0, '確' },
            { 0x01B1, '覚' },
            { 0x01B2, '角' },
            { 0x01B3, '較' },
            { 0x01B4, '隔' },
            { 0x01B5, '革' },
            { 0x01B6, '学' },
            { 0x01B7, '楽' },
            { 0x01B8, '顎' },
            { 0x01B9, '掛' },
            { 0x01BA, '割' },
            { 0x01BB, '活' },
            { 0x01BC, '滑' },
            { 0x01BD, '株' },
            { 0x01BE, '鎌' },
            { 0x01BF, '噛' },
            { 0x01C0, '刈' },
            { 0x01C1, '乾' },
            { 0x01C2, '冠' },
            { 0x01C3, '寒' },
            { 0x01C4, '動' },
            { 0x01C5, '巻' },
            { 0x01C6, '喚' },
            { 0x01C7, '完' },
            { 0x01C8, '干' },
            { 0x01C9, '幹' },
            { 0x01CA, '感' },
            { 0x01CB, '慣' },
            { 0x01CC, '換' },
            { 0x01CD, '敢' },
            { 0x01CE, '棺' },
            { 0x01CF, '歓' },
            { 0x01D0, '汗' },
            { 0x01D1, '環' },
            { 0x01D2, '甘' },
            { 0x01D3, '監' },
            { 0x01D4, '竿' },
            { 0x01D5, '答' },
            { 0x01D6, '簡' },
            { 0x01D7, '緩' },
            { 0x01D8, '観' },
            { 0x01D9, '貫' },
            { 0x01DA, '還' },
            { 0x01DB, '鑑' },
            { 0x01DC, '間' },
            { 0x01DD, '関' },
            { 0x01DE, '丸' },
            { 0x01DF, '含' },
            { 0x01E0, '眼' },
            { 0x01E1, '岩' },
            { 0x01E2, '頑' },
            { 0x01E3, '顔' },
            { 0x01E4, '願' },
            { 0x01E5, '危' },
            { 0x01E6, '喜' },
            { 0x01E7, '器' },
            { 0x01E8, '基' },
            { 0x01E9, '奇' },
            { 0x01EA, '嬉' },
            { 0x01EB, '寄' },
            { 0x01EC, '希' },
            { 0x01ED, '幾' },
            { 0x01EE, '揮' },
            { 0x01EF, '期' },
            { 0x01F0, '棄' },
            { 0x01F1, '帰' },
            { 0x01F2, '帰' },
            { 0x01F3, '気' },
            { 0x01F4, '祈' },
            { 0x01F5, '規' },
            { 0x01F6, '記' },
            { 0x01F7, '貴' },
            { 0x01F8, '起' },
            { 0x01F9, '輝' },
            { 0x01FA, '騎' },
            { 0x01FB, '亀' },
            { 0x01FC, '偽' },
            { 0x01FD, '儀' },
            { 0x01FE, '宜' },
            { 0x01FF, '技' },
            { 0x0200, '疑' },
            { 0x0201, '犠' },
            { 0x0202, '議' },
            { 0x0203, '吉' },
            { 0x0204, '詰' },
            { 0x0205, '却' },
            { 0x0206, '客' },
            { 0x0207, '脚' },
            { 0x0208, '虐' },
            { 0x0209, '逆' },
            { 0x020A, '久' },
            { 0x020B, '仇' },
            { 0x020C, '休' },
            { 0x020D, '及' },
            { 0x020E, '吸' },
            { 0x020F, '宮' },
            { 0x0210, '弓' },
            { 0x0211, '急' },
            { 0x0212, '救' },
            { 0x0213, '求' },
            { 0x0214, '汲' },
            { 0x0215, '泣' },
            { 0x0216, '球' },
            { 0x0217, '究' },
            { 0x0218, '級' },
            { 0x0219, '牛' },
            { 0x021A, '去' },
            { 0x021B, '居' },
            { 0x021C, '巨' },
            { 0x021D, '許' },
            { 0x021E, '距' },
            { 0x021F, '魚' },
            { 0x0220, '供' },
            { 0x0221, '共' },
            { 0x0222, '凶' },
            { 0x0223, '協' },
            { 0x0224, '叫' },
            { 0x0225, '境' },
            { 0x0226, '強' },
            { 0x0227, '恐' },
            { 0x0228, '教' },
            { 0x0229, '況' },
            { 0x022A, '狂' },
            { 0x022B, '挟' },
            { 0x022C, '胸' },
            { 0x022D, '脅' },
            { 0x022E, '興' },
            { 0x022F, '鏡' },
            { 0x0230, '響' },
            { 0x0231, '驚' },
            { 0x0232, '凝' },
            { 0x0233, '尭' },
            { 0x0234, '曲' },
            { 0x0235, '極' },
            { 0x0236, '玉' },
            { 0x0237, '巾' },
            { 0x0238, '禁' },
            { 0x0239, '筋' },
            { 0x023A, '緊' },
            { 0x023B, '近' },
            { 0x023C, '金' },
            { 0x023D, '銀' },
            { 0x023E, '九' },
            { 0x023F, '区' },
            { 0x0240, '苦' },
            { 0x0241, '駆' },
            { 0x0242, '具' },
            { 0x0243, '喰' },
            { 0x0244, '空' },
            { 0x0245, '偶' },
            { 0x0246, '遇' },
            { 0x0247, '屑' },
            { 0x0248, '掘' },
            { 0x0249, '窟' },
            { 0x024A, '熊' },
            { 0x024B, '繰' },
            { 0x024C, '勲' },
            { 0x024D, '君' },
            { 0x024E, '群' },
            { 0x024F, '軍' },
            { 0x0250, '袈' },
            { 0x0251, '傾' },
            { 0x0252, '刑' },
            { 0x0253, '兄' },
            { 0x0254, '型' },
            { 0x0255, '形' },
            { 0x0256, '恵' },
            { 0x0257, '憩' },
            { 0x0258, '敬' },
            { 0x0259, '景' },
            { 0x025A, '系' },
            { 0x025B, '経' },
            { 0x025C, '継' },
            { 0x025D, '繋' },
            { 0x025E, '茎' },
            { 0x025F, '蛍' },
            { 0x0260, '計' },
            { 0x0261, '警' },
            { 0x0262, '軽' },
            { 0x0263, '鶏' },
            { 0x0264, '迎' },
            { 0x0265, '劇' },
            { 0x0266, '撃' },
            { 0x0267, '激' },
            { 0x0268, '隙' },
            { 0x0269, '欠' },
            { 0x026A, '決' },
            { 0x026B, '潔' },
            { 0x026C, '穴' },
            { 0x026D, '結' },
            { 0x026E, '血' },
            { 0x026F, '月' },
            { 0x0270, '件' },
            { 0x0271, '健' },
            { 0x0272, '兼' },
            { 0x0273, '剣' },
            { 0x0274, '堅' },
            { 0x0275, '嫌' },
            { 0x0276, '建' },
            { 0x0277, '拳' },
            { 0x0278, '犬' },
            { 0x0279, '研' },
            { 0x027A, '肩' },
            { 0x027B, '見' },
            { 0x027C, '賢' },
            { 0x027D, '遣' },
            { 0x027E, '鍵' },
            { 0x027F, '険' },
            { 0x0280, '験' },
            { 0x0281, '元' },
            { 0x0282, '原' },
            { 0x0283, '厳' },
            { 0x0284, '幻' },
            { 0x0285, '弦' },
            { 0x0286, '減' },
            { 0x0287, '源' },
            { 0x0288, '玄' },
            { 0x0289, '現' },
            { 0x028A, '言' },
            { 0x028B, '限' },
            { 0x028C, '個' },
            { 0x028D, '古' },
            { 0x028E, '呼' },
            { 0x028F, '固' },
            { 0x0290, '己' },
            { 0x0291, '故' },
            { 0x0292, '枯' },
            { 0x0293, '湖' },
            { 0x0294, '誇' },
            { 0x0295, '雇' },
            { 0x0296, '鼓' },
            { 0x0297, '五' },
            { 0x0298, '互' },
            { 0x0299, '後' },
            { 0x029A, '御' },
            { 0x029B, '梧' },
            { 0x029C, '語' },
            { 0x029D, '護' },
            { 0x029E, '交' },
            { 0x029F, '光' },
            { 0x02A0, '公' },
            { 0x02A1, '功' },
            { 0x02A2, '効' },
            { 0x02A3, '厚' },
            { 0x02A4, '口' },
            { 0x02A5, '向' },
            { 0x02A6, '喉' },
            { 0x02A7, '好' },
            { 0x02A8, '孔' },
            { 0x02A9, '工' },
            { 0x02AA, '幸' },
            { 0x02AB, '広' },
            { 0x02AC, '庚' },
            { 0x02AD, '抗' },
            { 0x02AE, '拘' },
            { 0x02AF, '攻' },
            { 0x02B0, '更' },
            { 0x02B1, '構' },
            { 0x02B2, '溝' },
            { 0x02B3, '甲' },
            { 0x02B4, '皇' },
            { 0x02B5, '硬' },
            { 0x02B6, '紅' },
            { 0x02B7, '考' },
            { 0x02B8, '膏' },
            { 0x02B9, '荒' },
            { 0x02BA, '行' },
            { 0x02BB, '購' },
            { 0x02BC, '酵' },
            { 0x02BD, '鉱' },
            { 0x02BE, '鋼' },
            { 0x02BF, '降' },
            { 0x02C0, '香' },
            { 0x02C1, '高' },
            { 0x02C2, '剛' },
            { 0x02C3, '号' },
            { 0x02C4, '合' },
            { 0x02C5, '豪' },
            { 0x02C6, '刻' },
            { 0x02C7, '告' },
            { 0x02C8, '国' },
            { 0x02C9, '酷' },
            { 0x02CA, '黒' },
            { 0x02CB, '獄' },
            { 0x02CC, '骨' },
            { 0x02CD, '込' },
            { 0x02CE, '頃' },
            { 0x02CF, '今' },
            { 0x02D0, '困' },
            { 0x02D1, '昏' },
            { 0x02D2, '昆' },
            { 0x02D3, '恨' },
            { 0x02D4, '混' },
            { 0x02D5, '魂' },
            { 0x02D6, '些' },
            { 0x02D7, '左' },
            { 0x02D8, '差' },
            { 0x02D9, '査' },
            { 0x02DA, '砂' },
            { 0x02DB, '鎖' },
            { 0x02DC, '裟' },
            { 0x02DD, '座' },
            { 0x02DE, '催' },
            { 0x02DF, '再' },
            { 0x02E0, '最' },
            { 0x02E1, '塞' },
            { 0x02E2, '妻' },
            { 0x02E3, '採' },
            { 0x02E4, '済' },
            { 0x02E5, '災' },
            { 0x02E6, '砕' },
            { 0x02E7, '細' },
            { 0x02E8, '裁' },
            { 0x02E9, '載' },
            { 0x02EA, '際' },
            { 0x02EB, '剤' },
            { 0x02EC, '在' },
            { 0x02ED, '材' },
            { 0x02EE, '罪' },
            { 0x02EF, '坂' },
            { 0x02F0, '咲' },
            { 0x02F1, '作' },
            { 0x02F2, '削' },
            { 0x02F3, '索' },
            { 0x02F4, '察' },
            { 0x02F5, '殺' },
            { 0x02F6, '雑' },
            { 0x02F7, '捌' },
            { 0x02F8, '三' },
            { 0x02F9, '参' },
            { 0x02FA, '山' },
            { 0x02FB, '散' },
            { 0x02FC, '産' },
            { 0x02FD, '算' },
            { 0x02FE, '酸' },
            { 0x02FF, '斬' },
            { 0x0300, '残' },
            { 0x0301, '仕' },
            { 0x0302, '伺' },
            { 0x0303, '使' },
            { 0x0304, '刺' },
            { 0x0305, '司' },
            { 0x0306, '四' },
            { 0x0307, '士' },
            { 0x0308, '始' },
            { 0x0309, '姿' },
            { 0x030A, '子' },
            { 0x030B, '師' },
            { 0x030C, '思' },
            { 0x0311, '止' },
            { 0x0312, '死' },
            { 0x0313, '私' },
            { 0x0314, '糸' },
            { 0x031F, '字' },
            { 0x0321, '持' },
            { 0x0322, '時' },
            { 0x0327, '示' },
            { 0x0328, '耳' },
            { 0x0329, '自' },
            { 0x032E, '七' },
            { 0x032F, '叱' },
            { 0x0331, '失' },
            { 0x0336, '実' },
            { 0x033A, '者' },
            { 0x0340, '若' },
            { 0x0341, '弱' },
            { 0x0342, '主' },
            { 0x0344, '守' },
            { 0x0345, '手' },
            { 0x0346, '朱' },
            { 0x034E, '呪' },
            { 0x0350, '樹' },
            { 0x035C, '酬' },
            { 0x035F, '十' },
            { 0x0362, '汁' },
            { 0x0364, '重' },
            { 0x0365, '宿' },
            { 0x0366, '祝' },
            { 0x0369, '出' },
            { 0x0377, '助' },
            { 0x0378, '女' },
            { 0x0379, '序' },
            { 0x037A, '除' },
            { 0x037E, '召' },
            { 0x0381, '小' },
            { 0x0382, '少' },
            { 0x0383, '床' },
            { 0x0388, '消' },
            { 0x0394, '上' },
            { 0x0395, '丈' },
            { 0x0398, '場' },
            { 0x03A6, '尻' },
            { 0x03A7, '伸' },
            { 0x03AA, '心' },
            { 0x03AD, '新' },
            { 0x03AE, '森' },
            { 0x03B0, '深' },
            { 0x03B1, '申' },
            { 0x03B2, '真' },
            { 0x03B3, '神' },
            { 0x03B4, '芯' },
            { 0x03B6, '身' },
            { 0x03BB, '人' },
            { 0x03BC, '刃' },
            { 0x03C3, '水' },
            { 0x03CE, '世' },
            { 0x03F8, '戦' },
            { 0x0408, '前' },
            { 0x040A, '全' },
            { 0x041C, '総' },
            { 0x042A, '即' },
            { 0x042B, '息' },
            { 0x042C, '束' },
            { 0x042D, '測' },
            { 0x042E, '足' },
            { 0x042F, '速' },
            { 0x0430, '属' },
            { 0x0431, '族' },
            { 0x0432, '続' },
            { 0x0433, '袖' },
            { 0x0434, '揃' },
            { 0x0435, '存' },
            { 0x0436, '損' },
            { 0x0437, '他' },
            { 0x0438, '多' },
            { 0x0439, '太' },
            { 0x044B, '大' },
            { 0x0462, '団' },
            { 0x0469, '知' },
            { 0x046A, '地' },
            { 0x0470, '中' },
            { 0x0489, '沈' },
            { 0x0495, '定' },
            { 0x0497, '底' },
            { 0x04A4, '溺' },
            { 0x04A5, '哲' },
            { 0x04A6, '鉄' },
            { 0x04A7, '天' },
            { 0x04AC, '点' },
            { 0x04AD, '伝' },
            { 0x04BD, '刀' },
            { 0x04C2, '当' },
            { 0x04D0, '動' },
            { 0x04DC, '内' },
            { 0x04E1, '二' },
            { 0x04E2, '匂' },
            { 0x04E3, '肉' },
            { 0x04E4, '虹' },
            { 0x04E5, '日' },
            { 0x04E6, '入' },
            { 0x050D, '八' },
            { 0x050E, '発' },
            { 0x050F, '髪' },
            { 0x0510, '伐' },
            { 0x0511, '抜' },
            { 0x0512, '判' },
            { 0x0513, '半' },
            { 0x0514, '反' },
            { 0x0515, '板' },
            { 0x0516, '犯' },
            { 0x054E, '武' },
            { 0x0554, '復' },
            { 0x055B, '淵' },
            { 0x0564, '文' },
            { 0x0566, '併' },
            { 0x0568, '平' },
            { 0x057C, '母' },
            { 0x057F, '報' },
            { 0x0593, '冒' },
            { 0x0596, '防' },
            { 0x059D, '本' },
            { 0x05B3, '無' },
            { 0x05B5, '名' },
            { 0x05CB, '夜' },
            { 0x05FA, '頼' },
            { 0x0609, '立' },
            { 0x060D, '竜' },
            { 0x0610, '了' },
            { 0x0619, '力' },
            { 0x061A, '緑' },
            { 0x062A, '列' },
            { 0x0635, '六' },
            { 0x06B7, '昼' },
            { 0x06CA, 'Ⅰ' },
            { 0x06CD, 'Ⅳ' },
            { 0x06E5, 'Ⅴ' },
            { 0x06E6, 'α' },
            { 0x06E7, 'β' },
        };

        #endregion

        public static Dictionary<ushort, char> CharacterMap { get; private set; }

        public ushort[] RawData { get; private set; }
        public string ConvertedString { get; private set; }

        static GameDataManager.Versions gameVersion;
        public static GameDataManager.Versions GameVersion
        {
            get { return gameVersion; }
            set
            {
                gameVersion = value;

                if (gameVersion != GameDataManager.Versions.Japanese) CharacterMap = characterMapEnglish;
                else CharacterMap = characterMapJapanese;
            }
        }

        public EtrianString(string textString)
        {
            ConvertedString = textString;

            List<ushort> newRaw = new List<ushort>();

            for (int src = 0; src < ConvertedString.Length; src++)
            {
                int tagLength = ConvertedString.IndexOf('>', src) - src - 2;
                if (src + 1 < ConvertedString.Length && tagLength >= 0 && (ConvertedString[src] == '<' && ConvertedString[src + 1] == '!'))
                {
                    string tag = ConvertedString.Substring(src + 2, tagLength);

                    if (tag.StartsWith("pg")) newRaw.Add(0x8002);
                    else if (tag.StartsWith("color"))
                    {
                        newRaw.Add(0x8004);
                        newRaw.Add(ushort.Parse(tag.Substring(tag.IndexOf('=') + 1), System.Globalization.NumberStyles.HexNumber));
                    }
                    else
                        newRaw.Add(ushort.Parse(tag, System.Globalization.NumberStyles.HexNumber));

                    src += (tag.Length + 2);
                }
                else if (ConvertedString[src] == '\r' && ConvertedString[src + 1] == '\n')
                {
                    newRaw.Add(0x8001);
                    src++;
                }
                else if (ConvertedString[src] == '\n')
                {
                    newRaw.Add(0x8001);
                }
                else
                    newRaw.Add(CharacterMap.GetByValue(ConvertedString[src]));
            }

            RawData = newRaw.ToArray();
        }

        public EtrianString(ushort[] data)
        {
            ParseString(data);
        }

        public EtrianString(byte[] data, int offset)
        {
            int stringLength = -1;
            for (int i = 2; i < 0x2000; i += 2)
            {
                if (BitConverter.ToUInt16(data, offset + i) == 0x0000 &&
                    BitConverter.ToUInt16(data, offset + i - 2) != 0x8004)
                {
                    stringLength = i / 2;
                    break;
                }
            }

            ushort[] strData = new ushort[stringLength];
            Buffer.BlockCopy(data, offset, strData, 0, strData.Length * 2);
            ParseString(strData);
        }

        private void ParseString(ushort[] data)
        {
            RawData = data;

            if (RawData.Length != 0)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < RawData.Length; i++)
                {
                    if ((RawData[i] & 0x8000) == 0x8000 && !CharacterMap.ContainsKey(RawData[i]))
                    {
                        switch (RawData[i] & 0xFF)
                        {
                            case 0x01: builder.Append(Environment.NewLine); break;
                            case 0x02: builder.Append("<!pg>"); break;
                            case 0x04: builder.AppendFormat("<!color={0:X4}>", RawData[i + 1]); i++; break;
                            default: builder.AppendFormat("<!{0:X4}>", RawData[i]); break;
                        }
                    }
                    else
                    {
                        if (CharacterMap.ContainsKey(RawData[i])) builder.Append(CharacterMap[RawData[i]]);
                        else builder.AppendFormat("<!{0:X4}>", RawData[i]);
                    }
                }
                ConvertedString = builder.ToString();
            }
            else
                ConvertedString = string.Empty;
        }

        public static implicit operator EtrianString(string textString)
        {
            if (textString == null) return null;

            return new EtrianString(textString);
        }

        public static implicit operator EtrianString(ushort[] data)
        {
            if (data == null) return null;

            return new EtrianString(data);
        }

        public static implicit operator string(EtrianString etrianString)
        {
            if (etrianString == null) return null;

            return etrianString.ConvertedString;
        }

        public override string ToString()
        {
            return ConvertedString;
        }
    }
}
