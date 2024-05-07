using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WasteWiseEats_API.Domain.Enums
{
    public enum ERole
    {
        Unknown = 0,

        #region Dashboard

        [Description("ReadDashboards")]
        [Display(Name = "Visualizar gráficos")]
        ReadDashboards = 1,

        #endregion

        #region DonationCenter

        [Description("ListDonationCenters")]
        [Display(Name = "Listar centros de doação")]
        ListDonationCenters = 2,

        [Description("ReadDonationCenter")]
        [Display(Name = "Visualizar centro de doação")]
        ReadDonationCenter = 3,

        [Description("CreateDonationCenter")]
        [Display(Name = "Criar centro de doação")]
        CreateDonationCenter = 4,

        [Description("UpdateDonationCenter")]
        [Display(Name = "Atualizar centro de doação")]
        UpdateDonationCenter = 5,

        [Description("DeleteDonationCenter")]
        [Display(Name = "Deletar centro de doação")]
        DeleteDonationCenter = 6,

        #endregion

        #region DonationProposal

        [Description("ListDonationProposals")]
        [Display(Name = "Listar propostas de doação")]
        ListDonationProposals = 7,

        [Description("ReadDonationProposal")]
        [Display(Name = "Visualizar proposta de doação")]
        ReadDonationProposal = 8,

        [Description("CreateDonationProposal")]
        [Display(Name = "Criar proposta de doação")]
        CreateDonationProposal = 9,

        [Description("AcceptDonationProposal")]
        [Display(Name = "Aceitar proposta de doação")]
        AcceptDonationProposal = 10,

        [Description("DeleteDonationProposal")]
        [Display(Name = "Deletar proposta de doação")]
        DeleteDonationProposal = 11,

        #endregion

        #region Employee

        [Description("ListEmployees")]
        [Display(Name = "Listar funcionários")]
        ListEmployees = 12,

        [Description("ReadEmployee")]
        [Display(Name = "Visualizar funcionário")]
        ReadEmployee = 13,

        [Description("CreateEmployee")]
        [Display(Name = "Criar funcionário")]
        CreateEmployee = 14,

        [Description("UpdateEmployee")]
        [Display(Name = "Atualizar funcionário")]
        UpdateEmployee = 15,

        [Description("DeleteEmployee")]
        [Display(Name = "Deletar funcionário")]
        DeleteEmployee = 16,

        #endregion

        #region Restaurant

        [Description("ReadRestaurant")]
        [Display(Name = "Visualizar restaurante")]
        ReadRestaurant = 17,

        [Description("CreateRestaurant")]
        [Display(Name = "Criar restaurante")]
        CreateRestaurant = 18,

        [Description("UpdateRestaurant")]
        [Display(Name = "Atualizar funcionário")]
        UpdateRestaurant = 19,

        [Description("DeleteRestaurant")]
        [Display(Name = "Deletar restaurante")]
        DeleteRestaurant = 20,

        #endregion

        #region WasteRegister

        [Description("ListWasteRegisters")]
        [Display(Name = "Listar desperdícios")]
        ListWasteRegisters = 21,

        [Description("ReadWasteRegister")]
        [Display(Name = "Visualizar desperdício")]
        ReadWasteRegister = 22,

        [Description("CreateWasteRegister")]
        [Display(Name = "Criar desperdício")]
        CreateWasteRegister = 23,

        [Description("UpdateWasteRegister")]
        [Display(Name = "Atualizar desperdício")]
        UpdateWasteRegister = 24,

        [Description("DeleteWasteRegister")]
        [Display(Name = "Deletar desperdício")]
        DeleteWasteRegister = 25

        #endregion
    }
}
