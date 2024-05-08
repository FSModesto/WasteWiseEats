using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Extensions;

namespace WasteWiseEats_API.Data.Extensions
{
    public static class SeedExtensions
    {
        /// <summary>
        /// Aplica uma semente de dados no banco. 
        /// Adicione dados que conhecemos, como parâmetros de tabela ou uma entidades base.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ModelBuilder SetSeed(this ModelBuilder builder)
        {
            #region SecurityProfiles

            List<SecurityProfile> securityProfiles = new()
            {
                new()
                {
                    Id = SecurityProfile.SUPER_USER_ID,
                    Name = "Super Usuário",
                    Description = "Acesso irrestrito ao sistema."
                },
                new()
                {
                    Id = SecurityProfile.RESTAURANT_OWNER_ID,
                    Name = "Proprietário do restaurante",
                    Description = "Gerenciamento de funcionários e demandas do restaurante."
                },
                new()
                {
                    Id = SecurityProfile.RESTAURANT_ATENDANT_ID,
                    Name = "Atendente do restaurante",
                    Description = "Gerenciamento de desperdícios e cadastro de doações."
                },
                new()
                {
                    Id = SecurityProfile.DONATION_CENTER_OWNER_ID,
                    Name = "Proprietário do centro de doação",
                    Description = "Gerenciamento de propostas de doação"
                }
            };

            builder.Entity<SecurityProfile>()
                   .HasData(securityProfiles);

            #endregion

            #region SecurityProfileRoles

            IEnumerable<ERole> superUserRoles =
                EnumExtension.GetValues<ERole>(true);

            ERole[] donationCenterRoles =
            {
                ERole.CreateDonationCenter,
                ERole.UpdateDonationCenter,
                ERole.ReadDonationCenter,
                ERole.DeleteDonationCenter,
                ERole.ListDonationProposals,
                ERole.ReadDonationProposal,
                ERole.AcceptDonationProposal
            };

            ERole[] restaurantAtendantRoles =
            {
                ERole.ListDonationCenters,
                ERole.CreateDonationProposal,
                ERole.DeleteDonationProposal,
                ERole.CreateWasteRegister,
                ERole.UpdateWasteRegister,
                ERole.DeleteWasteRegister,
                ERole.ReadWasteRegister,
                ERole.ListWasteRegisters,
            };

            ERole[] restaurantOwnerRoles =
            {
                ERole.ReadDashboards,
                ERole.ListDonationCenters,
                ERole.ReadDonationCenter,
                ERole.CreateDonationProposal,
                ERole.DeleteDonationProposal,
                ERole.CreateEmployee,
                ERole.UpdateEmployee,
                ERole.ReadEmployee,
                ERole.ListEmployees,
                ERole.DeleteEmployee,
                ERole.CreateRestaurant,
                ERole.DeleteRestaurant,
                ERole.ReadRestaurant,
                ERole.CreateWasteRegister,
                ERole.UpdateWasteRegister,
                ERole.DeleteWasteRegister,
                ERole.ReadWasteRegister,
                ERole.ListWasteRegisters,
            };

            List<SecurityProfileRole> roles = new();

            roles.AddRange(GenerateSecurityProfileRoles(SecurityProfile.SUPER_USER_ID, superUserRoles));
            roles.AddRange(GenerateSecurityProfileRoles(SecurityProfile.DONATION_CENTER_OWNER_ID, donationCenterRoles));
            roles.AddRange(GenerateSecurityProfileRoles(SecurityProfile.RESTAURANT_ATENDANT_ID, restaurantAtendantRoles));
            roles.AddRange(GenerateSecurityProfileRoles(SecurityProfile.RESTAURANT_OWNER_ID, restaurantOwnerRoles));

            builder.Entity<SecurityProfileRole>()
                   .HasData(roles);


            #endregion

            return builder;
        }

        private static List<SecurityProfileRole> GenerateSecurityProfileRoles(Guid profileId, IEnumerable<ERole> roles)
        {
            return roles.Select(role => new SecurityProfileRole
            {
                Role = role,
                ProfileId = profileId
            }).ToList();
        }
    }
}
