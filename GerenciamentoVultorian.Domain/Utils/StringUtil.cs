using System.Text.RegularExpressions;

namespace GerenciamentoVultorian.Domain.Utils;

public static class StringUtil
{
    public static string ExtrairNumeros(this string str)
    {
        return string.Join("", Regex.Split(str, @"[^\d]"));
    }
    public static string FormatarParaCpf(this string cpf)
    {
        return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
    }
    public static string FormatarParaCelular(this string celular)
    {
        return long.Parse(celular).ToString(@"(00) 00 00000-0000");
    }
}