using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Repositories;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Domain.Services.Communication;
using AyniBackendWeb.Security.Domain.Repositories;

namespace AyniBackendWeb.Ayni.Services;

public class CropService : ICropService
{
    public readonly ICropRepository _cropRepository;
    public readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CropService(ICropRepository cropRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _cropRepository = cropRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Crop>> ListAsync()
    {
        return await _cropRepository.ListAsync();
    }

    public async Task<IEnumerable<Crop>> ListByUserIdAsync(int userId)
    {
        return await _cropRepository.FindByUserIdAsync(userId);
    }

    public async Task<CropResponse> SaveAsync(Crop crop)
    {
        // Validate UserId
        var existingUser = await 
            _userRepository.FindByIdAsync(crop.UserId);
        if (existingUser == null)
            return new CropResponse("Invalid User");
 
        // Validate Title
        var existingCropWithTitle = await 
            _cropRepository.FindByTitleAsync(crop.Name);
        if (existingCropWithTitle != null)
            return new CropResponse("Crop title already exists.");
        try
        {
            // Add Tutorial
            await _cropRepository.AddAsync(crop);
 
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
 
            // Return response
            return new CropResponse(crop);
        }
        catch (Exception e)
        {
            // Error Handling
            return new CropResponse($"An error occurred when saving the category: {e.Message}");
        }

    }

    public async Task<CropResponse> UpdateAsync(int cropId, Crop crop)
    {
        var existingCrop = await 
            _cropRepository.FindByIdAsync(cropId);
 
        // Validate Tutorial
        if (existingCrop == null)
            return new CropResponse("Tutorial not found.");
 
        // Modify Fields
        existingCrop.Name = crop.Name;
        existingCrop.Description = crop.Description;
        existingCrop.GroundType = crop.GroundType;
        existingCrop.Season = crop.Season;
        existingCrop.Weather = crop.Weather;
        existingCrop.Depth = crop.Depth;
        existingCrop.ImageUrl = crop.ImageUrl;
        existingCrop.Distance = crop.Distance;
        existingCrop.UserId = crop.UserId;
        
        try
        {
            _cropRepository.Update(existingCrop);
            await _unitOfWork.CompleteAsync();
            return new CropResponse(existingCrop);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new CropResponse($"An error occurred when updating the category: {e.Message}");
        }

    }

    public async Task<CropResponse> DeleteAsync(int cropId)
    {
        var existingCrop = await 
            _cropRepository.FindByIdAsync(cropId);
 
        // Validate Tutorial
        if (existingCrop == null)
            return new CropResponse("Tutorial not found.");
 
        try
        {
            _cropRepository.Remove(existingCrop);
            await _unitOfWork.CompleteAsync();
            return new CropResponse(existingCrop);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new CropResponse($"An error occurred when deleting the category: {e.Message}");
        }

    }
}