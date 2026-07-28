using EnterpriseStaffOperationsPlatform.Models;

namespace EnterpriseStaffOperationsPlatform.Services
{
    public class StaffService
    {
        //In-memory storage mechanism
        private List<StaffMember> staffMembers = new List<StaffMember>();

        //Add a staff member
        public void AddStaffMember(StaffMember staff)
        {
            staffMembers.Add(staff);
        }

        //Retrieve all staff members
        public List<StaffMember> GetAllStaffMembers()
        {
            return staffMembers;
        }

        //Retrieve a staff member by ID
        public StaffMember? GetStaffMemberById(int id)
        {
            StaffMember? existingStaff = staffMembers.FirstOrDefault(s => s.StaffId == id);

            return existingStaff;
        }

        //Update a staff member
        public bool UpdateStaffMember(StaffMember updatedStaff)
        {
            var existingStaff = staffMembers.FirstOrDefault(s => s.StaffId == updatedStaff.StaffId);

            if(existingStaff == null)
            {
                return false;
            }

            existingStaff.FullName = updatedStaff.FullName;
            existingStaff.Email = updatedStaff.Email;
            existingStaff.Position = updatedStaff.Position;
            existingStaff.Unit = updatedStaff.Unit;

            return true;
        }

        //Delete a staff member
        public bool DeleteStaffMember(int id)
        {
            var staff = staffMembers.FirstOrDefault(s => s.StaffId==id);

            if(staff == null)
            {
                return false;
            }

            staffMembers.Remove(staff);
            return true;
        }
    }
}
