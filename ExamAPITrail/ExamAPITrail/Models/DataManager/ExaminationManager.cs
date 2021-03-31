using ExamAPITrail.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPITrail.Models.DataManager
{
    public class ExaminationManager:IDataRepository<Examination>
    {
        readonly ExaminationContext _examinationContext;
        public ExaminationManager(ExaminationContext context)
        {
            _examinationContext = context;
        }
        public IEnumerable<Examination> GetAll()
        {
            return _examinationContext.Examinations.ToList();
        }
        public Examination Get(long id)
        {
            return _examinationContext.Examinations
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Examination entity)
        {
            _examinationContext.Examinations.Add(entity);
            _examinationContext.SaveChanges();
        }
        public void Update(Examination examination, Examination entity)
        {
            examination.Id = entity.Id;
            examination.Description = entity.Description;
            examination.IsDone = entity.IsDone;
            _examinationContext.SaveChanges();
        }
        public void Delete(Examination examination)
        {
            _examinationContext.Examinations.Remove(examination);
            _examinationContext.SaveChanges();
        }
    }
}
