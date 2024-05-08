using System.Net;
using WasteWiseEats_API.Domain.Attributes;

namespace WasteWiseEats_API.Domain.Exceptions.Enums
{
    public enum EApiException
    {
        #region Basic (1)

        Generic = 11,

        [StatusCodeError(HttpStatusCode.Unauthorized, "Login ou senha inválidos.")]
        AuthenticationFailure = 12,

        #endregion

        #region DonationCenter (2)

        [StatusCodeError(HttpStatusCode.NotFound, "Centro de doação não encontrado.")]
        DonationCenterNotFound = 21,

        [StatusCodeError(HttpStatusCode.BadRequest, "Já existe um centro de doação cadastrado para o usuário.")]
        DonationCenterAlreadyExists = 22,

        #endregion

        #region DonationProposal (3)

        [StatusCodeError(HttpStatusCode.NotFound, "Proposta de doação não encontrada.")]
        DonationProposalNotFound = 31,

        [StatusCodeError(HttpStatusCode.BadRequest, "Já existe uma proposta de doação cadastrada para este registro de desperdício.")]
        DonationProposalAlreadyExists = 32,

        [StatusCodeError(HttpStatusCode.BadRequest, "A proposta de doação já foi aceita pelo centro de doações, favor entrar em contato.")]
        DonationProposalAccepted = 33,

        #endregion

        #region Employee (4)

        [StatusCodeError(HttpStatusCode.NotFound, "Funcionário não encontrado.")]
        EmployeeNotFound = 41,

        [StatusCodeError(HttpStatusCode.BadRequest, "Já existe um funcionário cadastrado com esse documento.")]
        EmployeeAlreadyExists = 42,

        #endregion

        #region User (5)

        [StatusCodeError(HttpStatusCode.BadRequest, "Já existe um usuário cadastrado com esse email.")]
        EmailAlreadyExists = 51,

        [StatusCodeError(HttpStatusCode.BadRequest, "Usuário inativo.")]
        InactiveUser = 52,

        [StatusCodeError(HttpStatusCode.BadRequest, "Usuário já possui restaurante cadastrado.")]
        UserAlreadyHasRestaurant = 53,

        [StatusCodeError(HttpStatusCode.BadRequest, "Usuário já possui centro de doação cadastrado.")]
        UserAlreadyHasDonationCenter = 54,

        [StatusCodeError(HttpStatusCode.NotFound, "Usuário não encontrado.")]
        UserNotFound = 55,

        #endregion

        #region Restaurant (6)

        [StatusCodeError(HttpStatusCode.NotFound, "Restaurante não encontrado.")]
        RestaurantNotFound = 61,

        [StatusCodeError(HttpStatusCode.BadRequest, "Já existe um restaurante cadastrado com esse documento.")]
        RestaurantAlreadyExists = 62,

        #endregion

        #region SecurityProfile (7)

        [StatusCodeError(HttpStatusCode.BadRequest, "Perfil inválido")]
        InvalidSecurityProfile = 71,

        #endregion

        #region WasteRegister (8)

        [StatusCodeError(HttpStatusCode.NotFound, "Registro de desperdício não encontrado.")]
        WasteRegisterNotFound = 81,

        [StatusCodeError(HttpStatusCode.BadRequest, "Não foi possível deletar registro, há uma doação vinculada ao processo.")]
        WasteRegisterDeletionError = 82,

        #endregion
    }
}