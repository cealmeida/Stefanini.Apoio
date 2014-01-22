using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stefanini.Apoio.AIC.Persistencia.Repositorio;
using Stefanini.Apoio.AIC.Persistencia.xsd;
using Stefanini.Apoio.AIC.Persistencia.Interface;


namespace Stefanini.Apoio.AIC.Persistencia.Repositorio
{
    public class VidaEmpresarialRepositorio : IVidaEmpresarialRepositorio
    {
        public System.Data.DataTable MontaReportDataSource()
        {
            VidaEmpresarialSchema vidaSchema = new VidaEmpresarialSchema();

            ReportDataSource rds = new ReportDataSource();
            rds.DoDataTable(vidaSchema.Tables["Comando"]);
            rds.SemVias();
            rds.ComColunaDeValor("xml_pv_ag", "657721");
            rds.ComColunaDeValor("xml_pv_tipoag", "66666");
            rds.ComColunaDeValor("xml_pv_usu", "NANA CLARAs FONSECA SEREJO");

            rds.ComColunaDeValor("xml_pv_nome", "BRASILEIRO");
            rds.ComColunaDeValor("xml_pv_dt", "C");
            rds.ComColunaDeValor("xml_pv_hr", "CASADA");
            rds.ComColunaDeValor("xml_prod_cod", "M");

            rds.ComColunaDeValor("xml_prod_cod_sis", "1234567");
            rds.ComColunaDeValor("xml_prod_func", "SSP");
            rds.ComColunaDeValor("xml_dados_cpf_cnpj", "12345678912");
            rds.ComColunaDeValor("xml_dados_co_cli", "R");
            rds.ComColunaDeValor("xml_dados_tp_pes", "QUADRA SQS 203");

            rds.ComColunaDeValor("xml_dados_cart", "ASA SUL2");
            rds.ComColunaDeValor("xml_pj_raz", "70233090");
            rds.ComColunaDeValor("xml_pj_dt_const", "EMA1");

            rds.ComColunaDeValor("xml_pj_porte", "CE");
            rds.ComColunaDeValor("xml_pj_cnae", "61");

            rds.ComColunaDeValor("xml_pj_fat_anual", "30335580");
            rds.ComColunaDeValor("xml_pj_ddd1", String.Empty);
            rds.ComColunaDeValor("xml_pj_tel1", "QUADRA SQS 204");
            rds.ComColunaDeValor("xml_pj_ddd_fax", "ASA SUL");
            rds.ComColunaDeValor("xml_pj_tel_fax", "702330901");

            rds.ComColunaDeValor("xml_pd_logr", "EMA");
            rds.ComColunaDeValor("xml_pd_bair", "CE1");
            rds.ComColunaDeValor("xml_pd_cod_cid", "62");
            rds.ComColunaDeValor("xml_pd_cid", "33264373");
            rds.ComColunaDeValor("xml_pd_uf", "BLOCO I AP");
            rds.ComColunaDeValor("xml_pd_cep", String.Empty);
            rds.ComColunaDeValor("xml_cc_cc1", String.Empty);
            rds.ComColunaDeValor("xml_cc_cc2", String.Empty);

            rds.ComColunaDeValor("ipttipovenda", String.Empty);
            rds.ComColunaDeValor("iptagenciavalidavenda", String.Empty);
            rds.ComColunaDeValor("iptmatriculavendedor", String.Empty);
            rds.ComColunaDeValor("iptindicador", String.Empty);
            rds.ComColunaDeValor("xml_nu_via", String.Empty);
            rds.ComColunaDeValor("xml_ic_tipo", String.Empty);
            rds.ComColunaDeValor("xml_pv_op_pagamento", "F");
            rds.ComColunaDeValor("iptfaturamentoanual", "1982-01-01 00:00:00.0");
            rds.ComColunaDeValor("iptporte", "4");
            rds.ComColunaDeValor("iptdataconstituicao", "Ensino Superior");
            rds.ComColunaDeValor("ipttelefonecomercial", "N");
            rds.ComColunaDeValor("ipttelefonecelular", "69");
            rds.ComColunaDeValor("iptsms", "14.0");
            rds.ComColunaDeValor("iptinforme", "3.0");
            rds.ComColunaDeValor("iptemail", "1.0");
            rds.ComColunaDeValor("iptcpfcliente", "1.4286");
            rds.ComColunaDeValor("iptportetexto", String.Empty);

            rds.ComColunaDeValor("btnstepback", String.Empty);
            rds.ComColunaDeValor("nextstep", "AN0100");
            rds.ComColunaDeValor("estaavancando", "AUTO CREDITO 100MIL");
            rds.ComColunaDeValor("iptnomescoberturas", "0065772112345678912");
            rds.ComColunaDeValor("ipttipopagamentoproduto", "10498");

            rds.ComColunaDeValor("iptcoberturaselecionadarow", "22081");
            rds.ComColunaDeValor("iptcoberturaselecionadacapitalglobal", "45125");
            rds.ComColunaDeValor("iptcoberturaselecionadacapitalindividual", "063086");
            rds.ComColunaDeValor("iptcoberturaselecionadatotalvidas", "70000");
            rds.ComColunaDeValor("iptcoberturaselecionadacoberturasbasicas", "002462");
            rds.ComColunaDeValor("iptcoberturaselecionadacoberturasadicionais", "8");
            rds.ComColunaDeValor("iptpremiovalor", "59100000194570");
            rds.ComColunaDeValor("iptnumerorow1", "8220845125-5");
            rds.ComColunaDeValor("iptcoberturabasica1", "10498.22081  45125.063086  70000.002462 8  59100000194570");
            rds.ComColunaDeValor("iptcoberturabasicatexto1", "10498591000001945708220845125063087000000246");
            rds.ComColunaDeValor("iptcoberturasadicionaistexto1", String.Empty);
            rds.ComColunaDeValor("iptcoberturasadicionais1", String.Empty);
            rds.ComColunaDeValor("iptcapitalglobal1", String.Empty);

            rds.ComColunaDeValor("iptcapitalindividual1", String.Empty);
            rds.ComColunaDeValor("iptpremiovalor1", String.Empty);
            rds.ComColunaDeValor("ipttotalvidas1", String.Empty);
            rds.ComColunaDeValor("iptcoberturaselecionada", String.Empty);
            rds.ComColunaDeValor("iptnumerorow2", String.Empty);
            rds.ComColunaDeValor("iptcoberturabasica2", String.Empty);

            rds.ComColunaDeValor("iptcoberturabasicatexto2", String.Empty);
            rds.ComColunaDeValor("iptcoberturasadicionaistexto2", String.Empty);
            rds.ComColunaDeValor("iptcoberturasadicionais2", String.Empty);
            rds.ComColunaDeValor("iptcapitalglobal2", "23/11/2013");
            rds.ComColunaDeValor("iptcapitalindividual2", "23/12/2013");
            rds.ComColunaDeValor("iptpremiovalor2", "997");
            rds.ComColunaDeValor("ipttotalvidas2", "ANG");
            rds.ComColunaDeValor("btnstep", "Leiloeiro e afins");
            rds.ComColunaDeValor("ipttipopagamento", "4500.01");
            rds.ComColunaDeValor("iptvencimento", String.Empty);
            rds.ComColunaDeValor("iptccadesao", String.Empty);

            rds.ComColunaDeValor("iptdiadebitoadesao", "Móvel");
            rds.ComColunaDeValor("ipttipopagamentodemaisparcelas", "100000.0");
            rds.ComColunaDeValor("iptnumerocartao", "AUTO");
            rds.ComColunaDeValor("iptdiafatura", "0.068");
            rds.ComColunaDeValor("iptccdemaiscartao", "0.0");
            rds.ComColunaDeValor("iptdiadebitodemaiscartao", "1000");
            rds.ComColunaDeValor("iptccdemais", "2013-12-12 00:00:00.0");

            rds.ComColunaDeValor("iptdiadebitodemais", "BB");
            rds.ComColunaDeValor("txtagenciaterceiro", String.Empty);
            rds.ComColunaDeValor("iptoperacaodebitocontaterceiro", "0");
            rds.ComColunaDeValor("iptcontaterceiro", "104");
            rds.ComColunaDeValor("iptdigitoverificador", String.Empty);
            rds.ComColunaDeValor("iptcpfcnpjterceiro", "1945.7");
            rds.ComColunaDeValor("iptdiadebitoterceiro", "2013-12-11 00:00:00");
            rds.ComColunaDeValor("iptagenciaterceiro", String.Empty);
            rds.ComColunaDeValor("ipttipopagamentotexto", "S");
            rds.ComColunaDeValor("iptproduto", "88");
            rds.ComColunaDeValor("iptoperacaodebitocontaterceirotexto", String.Empty);
            rds.ComColunaDeValor("iptiscontaterceirovalida", "0");
            rds.ComColunaDeValor("ipttipopagamentodemaistexto", "00");
            rds.ComColunaDeValor("iptdadosccdemaistexto", String.Empty);
            rds.ComColunaDeValor("iptdadosccdemaiscartaotexto", String.Empty);
            rds.ComColunaDeValor("iptagenciacodcedente", String.Empty);

            rds.ComColunaDeValor("iptpremiotipo", "000");
            rds.ComColunaDeValor("iptdadosccadesaotexto", String.Empty);
            rds.ComColunaDeValor("iptagencia", "15");
            rds.ComColunaDeValor("iptjuncaodedadosconta", "12");
            rds.ComColunaDeValor("iptpremioid", "0.068");
            rds.ComColunaDeValor("iptclienteagencia", "90000.0");
            rds.ComColunaDeValor("iptclientenomeagencia", "150000.0");
            rds.ComColunaDeValor("iptclienteoperacao", "1.0");
            rds.ComColunaDeValor("iptclienteconta", "2.0");
            rds.ComColunaDeValor("iptclientecontadigito", "0.4024");
            rds.ComColunaDeValor("xml_prod_nu_linhadigitavelboleto", "0.1691");
            rds.ComColunaDeValor("xml_prod_nu_linhadigitavel", "1.2498");
            rds.ComColunaDeValor("xml_prod_nu_nossonumero", "1.4831");
            rds.ComColunaDeValor("xml_prod_nu_proposta", "0.0435");
            rds.ComColunaDeValor("iptdatavendaproposta", "0.0434");
            rds.ComColunaDeValor("iptnomerepresentante", "0.0431");
            rds.ComColunaDeValor("iptcpfrepresentante", "0.0432");
            return rds.ObtemReportDataSource();
        }
    }
}
