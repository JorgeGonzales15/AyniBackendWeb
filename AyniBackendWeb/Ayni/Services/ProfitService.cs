﻿using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Repositories;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Services;

public class ProfitService : IProfitService
{
    private readonly IProfitRepository _profitRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public ProfitService(IProfitRepository profitRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _profitRepository = profitRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Profit>> ListAsync()
    {
        return await _profitRepository.ListAsync();
    }

    public async Task<IEnumerable<Profit>> ListByUserIdAsync(int userId)
    {
        return await _profitRepository.FindByUserIdAsync(userId);
    }

    public async Task<ProfitResponse> SaveAsync(Profit profit)
    {
        // Validate UserId
        var existingUser = await 
            _userRepository.FindByIdAsync(profit.UserId);
        if (existingUser == null)
            return new ProfitResponse("Invalid User");
 
        // Validate Title
        var existingProfitWithTitle = await 
            _profitRepository.FindByTitleAsync(profit.NameP);
        if (existingProfitWithTitle != null)
            return new ProfitResponse("Crop title already exists.");
        try
        {
            // Add Tutorial
            await _profitRepository.AddAsync(profit);
 
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
 
            // Return response
            return new ProfitResponse(profit);
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProfitResponse($"An error occurred when saving the category: {e.Message}");
        }
    }

    public async Task<ProfitResponse> UpdateAsync(int profitId, Profit profit)
    {
        var existingProfit = await 
            _profitRepository.FindByIdAsync(profitId);
 
        // Validate Tutorial
        if (existingProfit == null)
            return new ProfitResponse("Tutorial not found.");
        // Validate CategoryId
        var existingUser = await 
            _userRepository.FindByIdAsync(profit.UserId);
        if (existingProfit == null)
            return new ProfitResponse("Invalid Category");
 
        // Validate Title
        var existingProfitWithTitle = await 
            _profitRepository.FindByTitleAsync(profit.NameP);
        if (existingProfitWithTitle != null && 
            existingProfitWithTitle.Id != existingProfit.Id)
            return new ProfitResponse("Tutorial title already exists.");
 
        // Modify Fields
        existingProfit.NameP = profit.NameP;
        existingProfit.DescriptionP = profit.DescriptionP;
        existingProfit.AmountP = profit.AmountP;
        existingProfit.UserId = profit.UserId;
        try
        {
            _profitRepository.Update(existingProfit);
            await _unitOfWork.CompleteAsync();
            return new ProfitResponse(existingProfit);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProfitResponse($"An error occurred when updating the category: {e.Message}");
        }
    }

    public async Task<ProfitResponse> DeleteAsync(int profitId)
    {
        var existingProfit = await 
            _profitRepository.FindByIdAsync(profitId);
 
        // Validate Tutorial
        if (existingProfit == null)
            return new ProfitResponse("Tutorial not found.");
 
        try
        {
            _profitRepository.Remove(existingProfit);
            await _unitOfWork.CompleteAsync();
            return new ProfitResponse(existingProfit);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new ProfitResponse($"An error occurred when deleting the category: {e.Message}");
        }
    }
}