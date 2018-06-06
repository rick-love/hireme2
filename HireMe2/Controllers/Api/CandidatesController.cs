using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HireMe2.Models;
using HireMe2.Dtos;
using AutoMapper;

namespace HireMe2.Controllers.Api
{
    public class CandidatesController : ApiController
    {
        private ApplicationDbContext _context;

        public CandidatesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/candidates
        public IEnumerable<CandidateDto> GetCandidates()
        {
            return _context.Candidates.ToList().Select(Mapper.Map<Candidate, CandidateDto>);
        }

        //Get /api/candidates/1
        public IHttpActionResult GetCandidate(int id)
        {
            var candidate = _context.Candidates.SingleOrDefault(c => c.Id == id);

            if (candidate == null)
                return NotFound();

            return Ok(Mapper.Map<Candidate, CandidateDto>(candidate));
        }

        //POST /api/candidates
        [HttpPost]
        public IHttpActionResult CreateCandidate(CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var candidate = Mapper.Map<CandidateDto, Candidate>(candidateDto);

            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            candidateDto.Id = candidate.Id;

            return Created(new Uri(Request.RequestUri + "/" + candidate.Id ), candidateDto);
        }

        // Put /api/candidates/1
        [HttpPut]
        public void UpdateCandidate(int id, CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var candidateInDb = _context.Candidates.SingleOrDefault(c => c.Id == id);

            if (candidateInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(candidateDto, candidateInDb);

            //NonActionAttribute longer needed after adding automapper
            //candidateInDb.Name = candidateDto.Name;
            //candidateInDb.Birthdate = candidateDto.Birthdate;
            //candidateInDb.WillReceiveRequisitionPosting = candidateDto.WillReceiveRequisitionPosting;
            //candidateInDb.MembershipTypeId = candidateDto.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/candidates/1
        [HttpDelete]
        public void DeleteCandidate(int id)
        {
            var candidateInDb = _context.Candidates.SingleOrDefault(c => c.Id == id);

            if (candidateInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Candidates.Remove(candidateInDb);
            _context.SaveChanges();
        }
    }
}
