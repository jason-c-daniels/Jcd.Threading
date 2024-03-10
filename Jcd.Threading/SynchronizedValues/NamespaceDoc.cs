using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

// ReSharper disable UnusedType.Global

namespace Jcd.Threading.SynchronizedValues;

/// <summary>
/// <para>
/// Provides generic types that encapsulate a value and a specific synchronization
/// primitive.
/// </para>
/// </summary>
/// <remarks>
/// <para>
/// The synchronization primitive is used to govern access to the underlying value.
/// These are useful for exchanging independent and atomic pieces of information
/// across threads.
/// </para>
/// <para>
/// NB: If using a reference type for the underlying value, ensure your reference
/// type is appropriately synchronized. In this case these types only restrict
/// access to the reference, not the data contained within the reference type.
/// </para>
/// </remarks>
[ExcludeFromCodeCoverage] // it's a marker class for documentation generation.
internal class NamespaceDoc;