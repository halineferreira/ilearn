using Assets.Data;
using Assets.Data.Queries;
using Assets.Data.Querybles;
using Assets.Domain.Core.Entities;
using Assets.Domain.Models.Filters;
using Assets.Domain.Models.Requests;
using Assets.Domain.Models.Responses;
using Assets.Domain.Templates;
using Assets.Infrastructure.UseCases.Filtering;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Infrastructure.UseCases.Search
{
  public interface IAssetSearchUseCase
  {
    Task<AssetsResponse> SearchAsync(AssetsRequest searchAssetsQuery, Pagination pagination, CancellationToken cancellationToken = default);

    Task<IAsyncCursor<gcp_canonical_model.Assets>> StreamSearchAsync(AssetsFilter filter, List<IdentifierFilter> identifiers, TemplateSort templateSort);
    Task<bool> VerifyAssetExistsAsync(AssetsRequest searchAssetsQuery);
    Task<IEnumerable<gcp_canonical_model.Assets>> ReplaceFriendlyNamesAsync(IEnumerable<gcp_canonical_model.Assets> assetsAgregation);
  }
  public class AssetSearchUseCase : IAssetSearchUseCase
  {
    private readonly IAssetFilteringLogic _assetFilteringLogic;
    private readonly IIdentifierFilteringLogic _identifierFilteringLogic;
    private readonly IMapper _mapper;
    private readonly IAssetsQueries _assetsQueries;
    private readonly IFieldDataFriendlyNameQueryable _fieldDataFriendlyNameQueryable;
    private readonly List<string> _fieldNames;

    public AssetSearchUseCase(
      IAssetFilteringLogic assetFilteringLogic,
      IIdentifierFilteringLogic identifierFilteringLogic,
      IAssetsQueries assetsQueries,
      IFieldDataFriendlyNameQueryable fieldDataFriendlyNameQueryable,
      IMapper mapper)
    {
      _assetFilteringLogic = assetFilteringLogic;
      _identifierFilteringLogic = identifierFilteringLogic;
      _assetsQueries = assetsQueries;
      _mapper = mapper;
      _fieldDataFriendlyNameQueryable = fieldDataFriendlyNameQueryable;
      _fieldNames = new List<string> { "LeaseType" };
    }

    public async Task<AssetsResponse> SearchAsync(
      AssetsRequest searchAssetsQuery,
      Pagination pagination,
      CancellationToken cancellationToken = default)
    {
      var assetFilterExpressions = _assetFilteringLogic.GetAssetFilterExpressions(searchAssetsQuery.Filters);
      var identifierFilterExpressions = _identifierFilteringLogic.GetIdentifierFilterExpressions(searchAssetsQuery.Identifiers);
      var featureRules = _mapper.Map<Dictionary<string, FeatureRules>>(searchAssetsQuery.Filters?.Rules);

      var (totalRecords, totalActiveCount, values) = await _assetsQueries.SearchAsync(
        assetFilterExpressions,
        identifierFilterExpressions,
        pagination.PageNumber,
        pagination.PageSize,
        pagination.SortBy,
        pagination.SortOrder,
        featureRules,
        cancellationToken
        );

      return new AssetsResponse { TotalCount = totalRecords, TotalActiveCount = totalActiveCount, Values = _mapper.Map<List<gcp_canonical_model.Assets>>(values) };
    }

    public async Task<bool> VerifyAssetExistsAsync(AssetsRequest searchAssetsQuery)
    {
      var assetFilterExpressions = _assetFilteringLogic.GetAssetFilterExpressions(searchAssetsQuery.Filters);
      var identifierFilterExpressions = _identifierFilteringLogic.GetIdentifierFilterExpressions(searchAssetsQuery.Identifiers);

      var totalRecords = await _assetsQueries.VerifyAssetExistsAsync(
        assetFilterExpressions,
        identifierFilterExpressions);

      return totalRecords;
    }

    public async Task<IAsyncCursor<gcp_canonical_model.Assets>> StreamSearchAsync(
      AssetsFilter filter,
      List<IdentifierFilter> identifiers, TemplateSort templateSort)
    {
      var assetFilterExpressions = _assetFilteringLogic.GetAssetFilterExpressions(filter);
      var identifierFilterExpressions = _identifierFilteringLogic.GetIdentifierFilterExpressions(identifiers);
      var featureRules = _mapper.Map<Dictionary<string, FeatureRules>>(filter?.Rules);

      var cursor = await _assetsQueries.StreamSearchAsync(
        assetFilterExpressions,
        identifierFilterExpressions,
        templateSort,
        featureRules);

      return cursor;
    }

    public async Task<IEnumerable<gcp_canonical_model.Assets>> ReplaceFriendlyNamesAsync(IEnumerable<gcp_canonical_model.Assets> assetsAgregation)
    {
      var filter = _fieldDataFriendlyNameQueryable.FieldDataFriendlyName
        .Where(x => x.Feature == "Contracts" && _fieldNames.Contains(x.FieldName));

      var friendlyNameList = await _fieldDataFriendlyNameQueryable.ToListAsync(filter);

      assetsAgregation.ToList().ForEach(a => friendlyNameList.ForEach(f =>
      {
        if (f.Region == a.Region && f.Country == a.Country && f.FieldName == "LeaseType" && f.CurrentName == a.ContractDetails.LeaseType)
          a.ContractDetails.LeaseType = f.FriendlyName;
      }));

      return assetsAgregation.ToList();

    }
  }
}
