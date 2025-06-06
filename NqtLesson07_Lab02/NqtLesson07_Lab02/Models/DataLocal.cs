using NqtLesson07_Lab02.Models;

public class DataLocal
{
    private readonly List<NqtPeople> _peoples;

    public DataLocal()
    {
        _peoples = new List<NqtPeople>
        {
            new NqtPeople
            {
                NqtID = 0,
                NqtName = "Nguyễn Quang Tâm",
                NqtEmail = "nguyenquangtam6666@gmail.com",
                NqtPhone = "0961138440",
                NqtAddress = "HN",
                NqtAvatar = "/images/avatar/1.jpg",
                NqtBirthday = Convert.ToDateTime("2005/06/26"),
                NqtBio = "nqtam",
                NqtGender = 0
            },
            new NqtPeople
            {
                NqtID = 1,
                NqtName = "Trịnh Văn Chung",
                NqtEmail = "chungtrinh@gmail.com",
                NqtPhone = "0978611889",
                NqtAddress = "25 Vũ Ngọc Phan",
                NqtAvatar = "/images/NqtAvatar/01.jpg",
                NqtBirthday = Convert.ToDateTime("1979/05/25"),
                NqtBio = "Devmaster Academy",
                NqtGender = 1
            },
            new NqtPeople
            {
                NqtID = 2,
                NqtName = "Nguyễn Huy",
                NqtEmail = "huynguyen@gmail.com",
                NqtPhone = "0912111311",
                NqtAddress = "Gia Lâm, Hà Nội",
                NqtAvatar = "/images/NqtAvatar/02.jpg",
                NqtBirthday = Convert.ToDateTime("1999/02/12"),
                NqtBio = "Học viên Devmaster",
                NqtGender = 1
            },
            new NqtPeople
            {
                NqtID = 3,
                NqtName = "Tiểu Long Nữ",
                NqtEmail = "longnuqualtue@gmail.com",
                NqtPhone = "09004001002",
                NqtAddress = "Ba Đình, Hà Nội",
                NqtAvatar = "/images/NqtAvatar/03.jpg",
                NqtBirthday = Convert.ToDateTime("2000/02/02"),
                NqtBio = "Nhân vật trong phim kiếm hiệp",
                NqtGender = 2
            },
            new NqtPeople
            {
                NqtID = 4,
                NqtName = "Pikachu",
                NqtEmail = "chupika@gmail.com",
                NqtPhone = "0902114115",
                NqtAddress = "Quảng Trường, Hà Đông",
                NqtAvatar = "/images/NqtAvatar/04.jpg",
                NqtBirthday = Convert.ToDateTime("1997/12/12"),
                NqtBio = "Nhân vật trong phim hoạt hình",
                NqtGender = 2
            }
        };
    }

    public void Add(NqtPeople model)
    {
        model.NqtID = _peoples.Any() ? _peoples.Max(p => p.NqtID) + 1 : 1; // Tạo ID tự động
        _peoples.Add(model);
    }

    public void Update(NqtPeople model)
    {
        var existing = _peoples.FirstOrDefault(p => p.NqtID == model.NqtID);
        if (existing != null)
        {
            _peoples.Remove(existing);
            _peoples.Add(model);
        }
    }

    public void Remove(NqtPeople model)
    {
        _peoples.Remove(model);
    }

    public async Task SaveChangesAsync()
    {
        // Giả lập lưu dữ liệu (danh sách đã được cập nhật trong Add/Update/Remove)
        await Task.CompletedTask;
    }

    public List<NqtPeople> GetNqtPeoples()
    {
        return _peoples;
    }

    public NqtPeople GetNqtPeopleByNqtID(int id)
    {
        return _peoples.FirstOrDefault(p => p.NqtID == id);
    }
}