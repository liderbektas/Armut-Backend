using Microsoft.AspNetCore.Mvc;
using Test_Case.Models;
using Test_Case.Services.Implementations;

namespace Test_Case.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
   private readonly OfferService _offerService;

   public OfferController(OfferService offerService)
   {
      _offerService = offerService;
   }

   [HttpPost("create-offer/{requestId}/{userId}")]
   public async Task<IActionResult> CreateOffer(int requestId, int userId, [FromBody] Offer offer)
   {
      try
      {
         var newOffer = await _offerService.CreateOfferAsync(requestId,userId,offer);
         return Ok(newOffer);
      }
      catch (Exception ex)
      {
         return StatusCode(400, new { message = "An error occurred while retrieving user requests.", error = ex.Message });

      }
   }

   [HttpGet("get-offer/{id}")]
   public async Task<ActionResult<Offer>> GetOfferById(int id)
   {
      try
      {
         var offer = await _offerService.GetOfferByUserIdAsync(id);
         return Ok(offer);
      }
      catch (Exception ex)
      {
         return StatusCode(400, new { message = "An error occurred while retrieving user requests.", error = ex.Message });
      }
   }

   [HttpGet("get-offer-by-request-id/{id}")]
   public async Task<ActionResult<Offer>> GetOfferByRequestId(int id)
   {
      try
      {
         var offer = await _offerService.GetOfferByRequestIdAsync(id);
         return Ok(offer);
      }
      catch (Exception ex)
      {
         return StatusCode(400, new { message = "An error occurred while retrieving user requests.", error = ex.Message });
      }
   }

   [HttpPut("update-offer/{id}")]
   public async Task<ActionResult<Offer>> UpdateOfferStatus(int id, OfferStatusDTO offer)
   {
      try
      {
         var offers = await _offerService.UpdateOfferStatusAsync(id , offer);
         return Ok(offers);
      }
      catch (Exception ex)
      {
         return StatusCode(400, new { message = ex.Message });
      }
   }

   [HttpPut("finish-offer/{finishOffferId}")]
   public async Task<ActionResult<Offer>> FinishOffer(int finishOffferId, [FromBody] CommentDTO request, [FromQuery] int authorId, [FromQuery] int recipientId)
   {
      try
      {
         var finishedOffer = await _offerService.FinishOfferAsync(finishOffferId, authorId, recipientId, request);
         return Ok(finishedOffer);
      }
      catch (Exception ex)
      {
         return StatusCode(400, new { message = ex.Message });
      }
   }

   
   [HttpGet("get-finish/{id}")]
   public async Task<IActionResult> GetFinish(int id)
   {
      try
      {
         var offer = await _offerService.GetFinishedOfferAsync(id);
         return Ok(offer);
      }
      catch (Exception ex)
      {
         return StatusCode(500, new { message = "Internal server error" , ex.Message });

      }
   }
}